using DevExpress.Web;
using DevExpress.Web.ASPxScheduler;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MainDemo.Module.Web {
    public class MyHorizontalResourceHeaderTemplate:ITemplate {
            public void InstantiateIn(System.Web.UI.Control container) {
                ResourceHeaderTemplateContainer resourceContainer = container as ResourceHeaderTemplateContainer;
                Table table = new Table();
                table.Width = new Unit("100%");
                table.Rows.Add(new TableRow());
                table.Rows[0].Cells.Add(new TableCell());
                ASPxBinaryImage image = new ASPxBinaryImage();
                image.Value = ImageToByte(resourceContainer.Resource.Image);
                table.Rows[0].Cells[0].Controls.Add(image);
                table.Rows.Add(new TableRow());
                table.Rows[1].Cells.Add(new TableCell());
                Literal lc = new Literal();
                lc.Text = resourceContainer.Resource.Caption;
                table.Rows[1].Cells[0].Controls.Add(lc);
                container.Controls.Add(table);
            }
            public static byte[] ImageToByte(System.Drawing.Image img) {
                ImageConverter converter = new ImageConverter();
                return (byte[])converter.ConvertTo(img,typeof(byte[]));
            }
        }
}
