using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ViewStateApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Fill ListBox dynamically!
                List<dynamic> arr = new List<dynamic>
                {
                    new {ID = 1 , Name = "Item 1" },
                    new {ID = 2 , Name = "Item 2" },
                    new {ID = 3 , Name = "Item 3" },
                };
                myListBox.DataSource = arr;
                myListBox.DataTextField = "Name";
                myListBox.DataBind();
            }
        }

        protected void btnPostback_Click(object sender, EventArgs e)
        {
            //No-op. this is just here to allow a post back
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Response.Write(ViewState.);
            ViewState["CustomViewStateItem"] = myListBox.SelectedItem.Text;
        }

        protected void btnGetValue_Click(object sender, EventArgs e)
        {
            lblVSValue.Text = (string)ViewState["CustomViewStateItem"];
        }
    }
}