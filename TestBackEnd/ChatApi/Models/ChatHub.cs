using CMSModule.Module.BusinessObjects.ChatSystem;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatApi.Models
{
    public class ChatHub : Hub
    {
        public static string emailIDLoaded = "";

        #region Connect
        public void Connect(string userName, string email)
        {
            emailIDLoaded = email;
            var id = Context.ConnectionId;
            var uow = new XpoDAO().ProvideUnitOfWork();
            var result = new XPCollection<ChatUserDetail>(uow);
            var item = result.FirstOrDefault(x => x.EmailID == email);
            if (item != null)
            {
                uow.Delete(item);
                //result.Remove(item);
                uow.CommitChanges();
                // Disconnect
                Clients.All.onUserDisconnectedExisting(item.ConnectionId, item.UserName);
            }
            var Users = result;
            if (Users.Where(x => x.EmailID == email).ToList().Count == 0)
            {

                var userdetails = new ChatUserDetail(uow)
                {
                    ConnectionId = id,
                    UserName = userName,
                    EmailID = email
                };
                uow.CommitChanges(); ;

                // send to caller
                var connectedUsers = result;
                var CurrentMessage = new XPCollection<ChatMessageDetail>(uow);// dc.ChatMessageDetails.ToList();
                List<TempChatMessageDetail> lstTempChatMessageDetail = new List<TempChatMessageDetail>();
                foreach (var currentMessage in CurrentMessage)
                {
                    lstTempChatMessageDetail.Add(new TempChatMessageDetail()
                    {
                        EmailID = currentMessage.EmailID,
                        Message = currentMessage.Message,
                        UserName = currentMessage.UserName
                    });
                }


                List<TempChatUserDetail> lstTempChatUserDetail = new List<TempChatUserDetail>();
                foreach (var user in connectedUsers)
                {
                    var tempChatUserDetail = new TempChatUserDetail()
                    {
                        ConnectionId = user.ConnectionId,
                        EmailID = user.EmailID,
                        UserName = user.UserName
                    };
                    lstTempChatUserDetail.Add(tempChatUserDetail);
                }
                Clients.Caller.onConnected(id, userName, lstTempChatUserDetail, lstTempChatMessageDetail);//connectedUsers
            }

            // send to all except caller client
            Clients.AllExcept(id).onNewUserConnected(id, userName, email);


        }
        #endregion

        #region Disconnect
        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            var uow = new XpoDAO().ProvideUnitOfWork();
            var result = new XPCollection<ChatUserDetail>(uow);
            var item = result.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                //result.Remove(item);
                uow.Delete(item);
                uow.CommitChanges();

                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.EmailID);
                //Clients.All.onUserDisconnected(id, item.UserName);
            }

            return base.OnDisconnected(stopCalled);
        }
        #endregion

        #region Send_To_All
        public void SendMessageToAll(string userName, string message)
        {
            // store last 100 messages in cache
            AddAllMessageinCache(userName, message);

            // Broad cast message
            Clients.All.messageReceived(userName, message);
        }
        #endregion

        #region Private_Messages
        public void SendPrivateMessage(string toUserId, string message, string status)
        {
            string fromUserId = Context.ConnectionId;
            var uow = new XpoDAO().ProvideUnitOfWork();
            var ChatUserDetails = new XPCollection<ChatUserDetail>(uow);
            var toUser = ChatUserDetails.FirstOrDefault(x => x.ConnectionId == toUserId);
            var fromUser = ChatUserDetails.FirstOrDefault(x => x.ConnectionId == fromUserId);
            if (toUser != null && fromUser != null)
            {
                if (status == "Click")
                    AddPrivateMessageinCache(fromUser.EmailID, toUser.EmailID, fromUser.UserName, message);

                // send to 
                Clients.Client(toUserId).sendPrivateMessage(fromUserId, fromUser.UserName, message, fromUser.EmailID, toUser.EmailID, status, fromUserId);

                // send to caller user
                Clients.Caller.sendPrivateMessage(toUserId, fromUser.UserName, message, fromUser.EmailID, toUser.EmailID, status, fromUserId);
            }

        }
        public List<PrivateChatMessage> GetPrivateMessage(string fromid, string toid, int take)
        {
            List<PrivateChatMessage> msg = new List<PrivateChatMessage>();
            var uow = new XpoDAO().ProvideUnitOfWork();
            var ChatUserDetails = new XPCollection<ChatPrivateMessageMaster>(uow);
            var ChatPrivateMessageDetails = new XPCollection<ChatPrivateMessageDetail>(uow);
            var v = (from a in ChatUserDetails
                     join b in ChatPrivateMessageDetails on a.EmailID equals b.MasterEmailID into cc
                     from c in cc
                     where (c.MasterEmailID.Equals(fromid) && c.ChatToEmailID.Equals(toid)) || (c.MasterEmailID.Equals(toid) && c.ChatToEmailID.Equals(fromid))
                     //orderby c.ID descending
                     select new
                     {
                         UserName = a.UserName,
                         Message = c.Message,
                         //ID = c.ID
                     }).Take(take).ToList();
            //v = v.OrderBy(s => s.ID).ToList();

            foreach (var a in v)
            {
                var res = new PrivateChatMessage()
                {
                    userName = a.UserName,
                    message = a.Message
                };
                msg.Add(res);
            }
            return msg;

        }

        private int takeCounter = 0;
        private int skipCounter = 0;
        public List<PrivateChatMessage> GetScrollingChatData(string fromid, string toid, int start = 10, int length = 1)
        {
            takeCounter = (length * start); // 20
            skipCounter = ((length - 1) * start); // 10
            List<PrivateChatMessage> msg = new List<PrivateChatMessage>();
            var uow = new XpoDAO().ProvideUnitOfWork();
            var ChatPrivateMessageMasters = new XPCollection<ChatPrivateMessageMaster>(uow);
            var ChatPrivateMessageDetails = new XPCollection<ChatPrivateMessageDetail>(uow);
            var v = (from a in ChatPrivateMessageMasters
                     join b in ChatPrivateMessageDetails on a.EmailID equals b.MasterEmailID into cc
                     from c in cc
                     where (c.MasterEmailID.Equals(fromid) && c.ChatToEmailID.Equals(toid)) || (c.MasterEmailID.Equals(toid) && c.ChatToEmailID.Equals(fromid))
                     //orderby c.ID descending
                     select new
                     {
                         UserName = a.UserName,
                         Message = c.Message,
                         //ID = c.ID
                     }).Take(takeCounter).Skip(skipCounter).ToList();

            foreach (var a in v)
            {
                var res = new PrivateChatMessage()
                {
                    userName = a.UserName,
                    message = a.Message
                };
                msg.Add(res);
            }
            return msg;

        }
        #endregion

        #region Save_Cache
        private void AddAllMessageinCache(string userName, string message)
        {
            var uow = new XpoDAO().ProvideUnitOfWork();
            var ChatMessageDetails = new XPCollection<ChatMessageDetail>(uow);
            var messageDetail = new ChatMessageDetail(uow)
            {
                UserName = userName,
                Message = message,
                EmailID = emailIDLoaded
            };
            ChatMessageDetails.Add(messageDetail);
            uow.CommitChanges();

        }

        private void AddPrivateMessageinCache(string fromEmail, string chatToEmail, string userName, string message)
        {
            var uow = new XpoDAO().ProvideUnitOfWork();
            var ChatPrivateMessageMasters = new XPCollection<ChatPrivateMessageMaster>(uow);
            // Save master
            var master = ChatPrivateMessageMasters.ToList().Where(a => a.EmailID.Equals(fromEmail)).ToList();
            if (master.Count == 0)
            {
                var result = new ChatPrivateMessageMaster(uow)
                {
                    EmailID = fromEmail,
                    UserName = userName
                };
                ChatPrivateMessageMasters.Add(result);
                uow.CommitChanges();
            }

            // Save details
            var ChatPrivateMessageDetails = new XPCollection<ChatPrivateMessageDetail>(uow);
            var resultDetails = new ChatPrivateMessageDetail(uow)
            {
                MasterEmailID = fromEmail,
                ChatToEmailID = chatToEmail,
                Message = message
            };
            ChatPrivateMessageDetails.Add(resultDetails);
            uow.CommitChanges();

        }
        #endregion


    }

    public class PrivateChatMessage
    {
        public string userName { get; set; }
        public string message { get; set; }
    }

    public class TempChatUserDetail
    {
        public string EmailID;
        public string UserName;
        public string ConnectionId;
    }
    public class TempChatMessageDetail
    {
        public string EmailID;
        public string Message;
        public string UserName;
    }
}














//using (NAANSolutionCMSEntities1 dc = new NAANSolutionCMSEntities1())
//{
//    var item = dc.ChatUserDetails.FirstOrDefault(x => x.EmailID == email);
//    if (item != null)
//    {
//        dc.ChatUserDetails.Remove(item);
//        dc.SaveChanges();

//        // Disconnect
//        Clients.All.onUserDisconnectedExisting(item.ConnectionId, item.UserName);
//    }

//    var Users = dc.ChatUserDetails.ToList();
//    if (Users.Where(x => x.EmailID == email).ToList().Count == 0)
//    {
//        var userdetails = new ChatUserDetail
//        {
//            ConnectionId = id,
//            UserName = userName,
//            EmailID = email
//        };
//        dc.ChatUserDetails.Add(userdetails);
//        dc.SaveChanges();

//        // send to caller
//        var connectedUsers = dc.ChatUserDetails.ToList();
//        var CurrentMessage = dc.ChatMessageDetails.ToList();
//        Clients.Caller.onConnected(id, userName, connectedUsers, CurrentMessage);
//    }

//    // send to all except caller client
//    Clients.AllExcept(id).onNewUserConnected(id, userName, email);
//}

//using (NAANSolutionCMSEntities1 dc = new NAANSolutionCMSEntities1())
//{
//    var item = dc.ChatUserDetails.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
//    if (item != null)
//    {
//        dc.ChatUserDetails.Remove(item);
//        dc.SaveChanges();

//        var id = Context.ConnectionId;
//        Clients.All.onUserDisconnected(id, item.UserName);
//    }
//}

//using (NAANSolutionCMSEntities1 dc = new NAANSolutionCMSEntities1())
//{
//    var toUser = dc.ChatUserDetails.FirstOrDefault(x => x.ConnectionId == toUserId);
//    var fromUser = dc.ChatUserDetails.FirstOrDefault(x => x.ConnectionId == fromUserId);
//    if (toUser != null && fromUser != null)
//    {
//        if (status == "Click")
//            AddPrivateMessageinCache(fromUser.EmailID, toUser.EmailID, fromUser.UserName, message);

//        // send to 
//        Clients.Client(toUserId).sendPrivateMessage(fromUserId, fromUser.UserName, message, fromUser.EmailID, toUser.EmailID, status, fromUserId);

//        // send to caller user
//        Clients.Caller.sendPrivateMessage(toUserId, fromUser.UserName, message, fromUser.EmailID, toUser.EmailID, status, fromUserId);
//    }
//}

//using (NAANSolutionCMSEntities1 dc = new NAANSolutionCMSEntities1())
//{
//    List<PrivateChatMessage> msg = new List<PrivateChatMessage>();

//    var v = (from a in dc.ChatPrivateMessageMasters
//             join b in dc.ChatPrivateMessageDetails on a.EmailID equals b.MasterEmailID into cc
//             from c in cc
//             where (c.MasterEmailID.Equals(fromid) && c.ChatToEmailID.Equals(toid)) || (c.MasterEmailID.Equals(toid) && c.ChatToEmailID.Equals(fromid))
//             orderby c.ID descending
//             select new
//             {
//                 UserName = a.UserName,
//                 Message = c.Message,
//                 ID = c.ID
//             }).Take(take).ToList();
//    v = v.OrderBy(s => s.ID).ToList();

//    foreach (var a in v)
//    {
//        var res = new PrivateChatMessage()
//        {
//            userName = a.UserName,
//            message = a.Message
//        };
//        msg.Add(res);
//    }
//    return msg;
//}

//using (NAANSolutionCMSEntities1 dc = new NAANSolutionCMSEntities1())
//{
//    List<PrivateChatMessage> msg = new List<PrivateChatMessage>();
//    var v = (from a in dc.ChatPrivateMessageMasters
//             join b in dc.ChatPrivateMessageDetails on a.EmailID equals b.MasterEmailID into cc
//             from c in cc
//             where (c.MasterEmailID.Equals(fromid) && c.ChatToEmailID.Equals(toid)) || (c.MasterEmailID.Equals(toid) && c.ChatToEmailID.Equals(fromid))
//             orderby c.ID descending
//             select new
//             {
//                 UserName = a.UserName,
//                 Message = c.Message,
//                 ID = c.ID
//             }).Take(takeCounter).Skip(skipCounter).ToList();

//    foreach (var a in v)
//    {
//        var res = new PrivateChatMessage()
//        {
//            userName = a.UserName,
//            message = a.Message
//        };
//        msg.Add(res);
//    }
//    return msg;
//}

//using (NAANSolutionCMSEntities1 dc = new NAANSolutionCMSEntities1())
//{
//    var messageDetail = new ChatMessageDetail
//    {
//        UserName = userName,
//        Message = message,
//        EmailID = emailIDLoaded
//    };
//    dc.ChatMessageDetails.Add(messageDetail);
//    dc.SaveChanges();
//}

//using (NAANSolutionCMSEntities1 dc = new NAANSolutionCMSEntities1())
//{
//    // Save master
//    var master = dc.ChatPrivateMessageMasters.ToList().Where(a => a.EmailID.Equals(fromEmail)).ToList();
//    if (master.Count == 0)
//    {
//        var result = new ChatPrivateMessageMaster
//        {
//            EmailID = fromEmail,
//            UserName = userName
//        };
//        dc.ChatPrivateMessageMasters.Add(result);
//        dc.SaveChanges();
//    }

//    // Save details
//    var resultDetails = new ChatPrivateMessageDetail
//    {
//        MasterEmailID = fromEmail,
//        ChatToEmailID = chatToEmail,
//        Message = message
//    };
//    dc.ChatPrivateMessageDetails.Add(resultDetails);
//    dc.SaveChanges();
//}