using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace MESProject.생산계획
{
    public partial class PLAN_MST : Form
    {
        public static SqlConnection con = new SqlConnection("server = 222.235.141.8;"
                                                           + "Database=KFQB_MES_2021;"
                                                           + "Uid=kfqb;"
                                                           + "Pwd=2211;");

        public PLAN_MST()
        {
            InitializeComponent();
        }

     
        

        private void PLAN_MST_Load(object sender, EventArgs e)
        {
           
        }
    }
}
