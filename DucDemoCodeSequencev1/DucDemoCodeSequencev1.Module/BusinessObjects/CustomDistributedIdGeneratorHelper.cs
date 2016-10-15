using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.Xpo.DB.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DucDemoCodeSequencev1.Module.BusinessObjects
{
    public static class CustomDistributedIdGeneratorHelper
    {
        public const int MaxIdGenerationAttemptsCounter = 7;
        static bool first = true;
        static OidGenerator generator = null;
        public static string Generate(IDataLayer idGeneratorDataLayer, Type seqType, bool save, string code)
        {
            //OidGenerator generator = null;
            string strNeedTrim = "";
            string prefixcode = "";
            Session generatorSession = new Session(idGeneratorDataLayer);
            var csc = generatorSession.FindObject<CodeSequenceConfig>(
                          new BinaryOperator("Type", seqType)
            );
            if (csc != null)
            {
                strNeedTrim = csc.Prefix != null ? csc.Prefix : "";
                strNeedTrim += csc.DelimiterFirst != null ? csc.DelimiterFirst : "";
                switch (csc.PrefixPartType)
                {
                    case PrefixPartType.String: break;
                    case PrefixPartType.IssueDate:
                        var d = DateTime.Now;
                        string dmy = d.Day + "/" + d.Month + "/" + d.Year;
                        strNeedTrim += dmy;
                        strNeedTrim = NNE(csc.DelimiterSecond) == true ? strNeedTrim + csc.DelimiterSecond : strNeedTrim;
                        break;
                    default: break;
                }
            }
            else
            {
                csc = new CodeSequenceConfig(generatorSession);
                csc.Type = seqType;
                csc.Save();
            }

            code = code != null ? code.Trim() : code;
            //case 1: user nhap ma -> ko tao ma tu sinh
            if (NNE(code))
            {
                string isNumber;
                int codeUserNhapKetThucVoi;
                if (strNeedTrim != "")
                {
                    var match = Regex.Match(code, strNeedTrim);
                    //Regex r = new Regex(strNeedTrim, RegexOptions.IgnoreCase);                    
                    //var match = r.Match(code);
                    if (match.Success)
                    {
                        isNumber = code.Replace(strNeedTrim, "");
                        if (isNumberic(isNumber, out codeUserNhapKetThucVoi))//neu la kieu so // user nhap Duc|9/8/1985|9
                        {
                            CriteriaOperator cr = new FunctionOperator(FunctionOperatorType.EndsWith, new OperandProperty("Code"), codeUserNhapKetThucVoi.ToString());
                            var a = generatorSession.FindObject(seqType, cr);
                            if (a != null)
                            {
                                //generator.Save();
                                //throw new UserFriendlyException("Code Exist!");
                                while (a != null)
                                {
                                    generator.Oid++;
                                    var mr = new FunctionOperator(FunctionOperatorType.EndsWith, new OperandProperty("Code"), generator.Oid.ToString());
                                    a = generatorSession.FindObject(seqType, mr);
                                }
                            }
                            
                            CriteriaOperator cre = new FunctionOperator(FunctionOperatorType.EndsWith, new OperandProperty("Code"), generator.Oid.ToString());
                            var aa = generatorSession.FindObject(seqType, cre);//new BinaryOperator("Code", generator.Oid,BinaryOperatorType.Equal)
                            while (aa != null)
                            {
                                generator.Oid++;
                                cre = new FunctionOperator(FunctionOperatorType.EndsWith, new OperandProperty("Code"), generator.Oid.ToString());
                                aa = generatorSession.FindObject(seqType, cre);
                            }
                            generator.Save();
                            code = strNeedTrim + string.Format("{0:D" + csc.ZeroDisplay + "}", generator.Oid);
                            return code;
                        }
                    }
                }
                CriteriaOperator criteriaEndWith = new FunctionOperator(FunctionOperatorType.EndsWith, new OperandProperty("Code"), code);
                var tt = generatorSession.FindObject(seqType, criteriaEndWith);
                if (tt != null)
                {
                    throw new UserFriendlyException("Code Exist!");
                }
                return code;
            }
            else
            {
                for (int attempt = 1; ; ++attempt)
                {
                    try
                    {
                        string prefixcodeformat = strNeedTrim + string.Format("{0:D" + csc.ZeroDisplay + "}", 0);
                        generator = generatorSession.FindObject<OidGenerator>(
                            CriteriaOperator.And(
                                new BinaryOperator("Type", seqType.FullName)
                            )
                        );
                        if (generator == null)
                        {
                            generator = new OidGenerator(generatorSession);
                            generator.Type = seqType.FullName;
                            generator.Prefix = prefixcodeformat;
                            generator.Oid = 1;
                        }
                        else
                            generator.Oid++;
                        if (save)
                        {
                            CriteriaOperator criteriaEndWith = new FunctionOperator(FunctionOperatorType.EndsWith, new OperandProperty("Code"), generator.Oid.ToString());
                            var tt = generatorSession.FindObject(seqType, criteriaEndWith);//new BinaryOperator("Code", generator.Oid,BinaryOperatorType.Equal)
                            while (tt != null)
                            {
                                generator.Oid++;
                                criteriaEndWith = new FunctionOperator(FunctionOperatorType.EndsWith, new OperandProperty("Code"), generator.Oid.ToString());
                                tt = generatorSession.FindObject(seqType, criteriaEndWith);
                            }
                            generator.Save();
                        }
                        prefixcode = strNeedTrim + string.Format("{0:D" + csc.ZeroDisplay + "}", generator.Oid);
                        return strNeedTrim + string.Format("{0:D" + csc.ZeroDisplay + "}", generator.Oid);
                    }
                    catch (LockingException)
                    {
                        if (attempt >= MaxIdGenerationAttemptsCounter)
                            throw;
                    }
                }
            }
        }
        private static OidGenerator FindOrCreateOidGenerator(Type seqType, Session generatorSession)
        {
            OidGenerator generator = generatorSession.FindObject<OidGenerator>(
                        new GroupOperator(new BinaryOperator("Type", seqType.FullName))
            );
            if (generator == null)
            {
                generator = new OidGenerator(generatorSession);
                generator.Type = seqType.FullName;
                generator.Prefix = "";
            }
            return generator;
        }

        public static string Generate(IDataLayer idGeneratorDataLayer, Type seqType, string code)
        {
            return Generate(idGeneratorDataLayer, seqType, true, code);
        }

        public static bool NNE(string inputString)
        {
            if (!string.IsNullOrEmpty(inputString))
            {
                return true;
            }
            return false;
        }

        //use :int num;
        //     if(isNumberic("AAA",out num))
        //     Console.WriteLine(num);
        private static bool isNumberic(string str, out int num)
        {
            return int.TryParse(str, out num);
        }
    }
}
