using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FP.BL.DealSlipFX;
using System.Drawing.Printing;
using FP.Common.ExceptionLogging;


namespace DealSlipFX
{
    public partial class DealSlipFXForm : Form
    {
        public DealSlipFXForm()
        {
            InitializeComponent();
        }

        DealSlipFXMaster _oDealSlipFXMaster = null;
        DataSet dsFormCaptions = null;
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //bool Result = false;
                _oDealSlipFXMaster = new DealSlipFXMaster();

                _oDealSlipFXMaster.ClientName = txtClientName.Text.ToString().Length > 0 ? txtClientName.Text : null;
                if (txtSerialNo.Text.Length > 0)
                    _oDealSlipFXMaster.SerialNo = Convert.ToInt32(txtSerialNo.Text);
                _oDealSlipFXMaster.CreatedDate = Convert.ToDateTime(txtDate.Text.ToString());
                _oDealSlipFXMaster.Bought = chkBought.Checked;
                _oDealSlipFXMaster.Sold = chkSold.Checked;
                _oDealSlipFXMaster.Swap = chkSwap.Checked;
                _oDealSlipFXMaster.Tod = chkTod.Checked;
                _oDealSlipFXMaster.Tom = chkTom.Checked;
                _oDealSlipFXMaster.Spot = chkSpot.Checked;
                _oDealSlipFXMaster.Forward = chkForward.Checked;
                _oDealSlipFXMaster.Time = txtTime.Text.ToString().Length > 0 ? txtTime.Text : null;
                _oDealSlipFXMaster.CCYBought = txtccyBought.Text.ToString().Length > 0 ? txtccyBought.Text : null;
                if(txtBoughtAmount.Text.Length>0)
                _oDealSlipFXMaster.BoughtAmount =Convert.ToDecimal(txtBoughtAmount.Text);
                if(txtExchangeRate.Text.Length>0)
                _oDealSlipFXMaster.ExchangeRate =Convert.ToDecimal(txtExchangeRate.Text);
                _oDealSlipFXMaster.CCYSold = txtccySold.Text.ToString().Length > 0 ? txtccySold.Text : null;
                if(txtSoldAmount.Text.Length>0)
                _oDealSlipFXMaster.SoldAmount=Convert.ToDecimal(txtSoldAmount.Text);
                _oDealSlipFXMaster.ValueDate = Convert.ToDateTime(dateTimePicker1.Text);
                _oDealSlipFXMaster.ReceiveThrough = txtReceivedThrough.Text.Length > 0 ? txtReceivedThrough.Text : null;
                _oDealSlipFXMaster.DeliverTo = txtDeliverTo.Text.Length > 0 ? txtDeliverTo.Text : null;
                _oDealSlipFXMaster.PurposePurchaseSale = txtPurpose.Text.Length > 0 ? txtPurpose.Text : null;
                if(txtDepositRate.Text.Length>0)
                _oDealSlipFXMaster.DepositRate = Convert.ToDecimal(txtDepositRate.Text);
                if (txtDepositInterest.Text.Length > 0)
                _oDealSlipFXMaster.DepositInterest = Convert.ToDecimal(txtDepositInterest.Text);
                if(txtDepositTenor.Text.Length>0)
                _oDealSlipFXMaster.DepositTenor = Convert.ToDecimal(txtDepositTenor.Text);
                if(txtDepositMaturity.Text.Length>0)
                _oDealSlipFXMaster.DepositMaturity = Convert.ToDecimal(txtDepositMaturity.Text);
                if(txtPlacementRate.Text.Length>0)
                _oDealSlipFXMaster.PlacementRate = Convert.ToDecimal(txtPlacementRate.Text);
                if (txtPlacementInterest.Text.Length > 0)
                _oDealSlipFXMaster.PlacementInterest = Convert.ToDecimal(txtPlacementInterest.Text);
                if (txtPlacementTenor.Text.Length > 0)
                _oDealSlipFXMaster.PlacementTenor = Convert.ToDecimal(txtPlacementTenor.Text);
                if (txtPlacementMaturity.Text.Length > 0)
                _oDealSlipFXMaster.PlacementMaturity = Convert.ToDecimal(txtPlacementMaturity.Text);

               int Result = _oDealSlipFXMaster.AddDealSlipFXDetails();

                if (Result>0)
                {
                    MessageBox.Show("Receipt added successfully.", "Electronic Receipt ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _oDealSlipFXMaster.UpdateSerialNo();
                    ClearText();
                    BindData();
                }
                else
                {
                    MessageBox.Show("Receipt not added successfully.", "Electronic Receipt ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("There was some issue,Please kindly contact IT Administrator", "Electronic Receipt ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new FPException("DealSlipFX.btnSave_Click()" + ex.Message.ToString(), FPException.ErrorType.Error);
            }
        }

        private void DealSlipFXForm_Load(object sender, EventArgs e)
        {
            //txtDate.Text =System.DateTime.Today.ToString("dd-MMM-yyyy");
            //txtTime.Text = DateTime.Now.ToShortTimeString();
            //txtSerialNo.Text = GetSerialNo().ToString();
            BindData();
        }

        public void BindData()
        {
            txtDate.Text = System.DateTime.Today.ToString("dd-MMM-yyyy");
            txtTime.Text = DateTime.Now.ToShortTimeString();
            txtSerialNo.Text = GetSerialNo().ToString();
        }

        public int GetSerialNo()
        { 
            int SerialNo=0;
            DataSet ds = new DataSet();
            _oDealSlipFXMaster = new DealSlipFXMaster();

            ds = _oDealSlipFXMaster.GetSerialNo();
            if (ds.Tables[0].Rows.Count > 0)
            {
                SerialNo = Convert.ToInt32(ds.Tables[0].Rows[0]["SerialNo"].ToString()) + 1;
            }
            return SerialNo;
        }
        public void ClearText()
        {
            txtDate.Text = "";
            chkBought.Checked = false;
            chkSold.Checked = false;
            chkSwap.Checked = false;
            chkTod.Checked = false;
            chkTom.Checked = false;
            chkSpot.Checked = false;
            chkForward.Checked = false;
            txtSerialNo.Text = "";
            txtTime.Text = "";
            txtClientName.Text = "";
            txtccyBought.Text = "";
            txtBoughtAmount.Text = "";
            txtExchangeRate.Text = "";
            txtccySold.Text = "";
            txtSoldAmount.Text = "";
            txtReceivedThrough.Text = "";
            txtDeliverTo.Text = "";
            txtPurpose.Text = "";
            txtDepositRate.Text = "";
            txtDepositInterest.Text = "";
            txtDepositTenor.Text = "";
            txtDepositMaturity.Text = "";
            txtPlacementRate.Text = "";
            txtPlacementInterest.Text = "";
            txtPlacementTenor.Text = "";
            txtPlacementMaturity.Text = "";
        }

        private void PrintRecipt()
        {

            PrintDocument pd = new PrintDocument();
            System.Drawing.Printing.PrintController standardPrintController = new System.Drawing.Printing.StandardPrintController();
            pd.PrintController = standardPrintController;

            pd.PrintPage += new PrintPageEventHandler(pd_RecieptReport);
            pd.Print();
        }

        void pd_RecieptReport(object sender, PrintPageEventArgs e)
        {
            try
            {
                e.PageSettings.PrinterSettings.DefaultPageSettings.Margins.Bottom = 50;
                float yPos = 10;
                float leftMargin = 15;
                float centre = this.Width / 2;
                Pen pen = new Pen(Brushes.Black);
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                Font printFont = new System.Drawing.Font("Courier New", 8, FontStyle.Bold);
                Font printFontService = new System.Drawing.Font("Courier New", 14, FontStyle.Bold);
                Font printFontTokenNo = new System.Drawing.Font("Courier New", 12, FontStyle.Bold);
                Font printFont1 = new System.Drawing.Font("Courier New", 8, FontStyle.Bold);
                Font printFontDateMsg = new System.Drawing.Font("Courier New", 9, FontStyle.Bold);
                Font printFontDate = new System.Drawing.Font("Courier New", 9, FontStyle.Bold);

                Point p = new Point(60, 10);
                try
                {
                    PictureBox k = new PictureBox();
                    k.Image = System.Drawing.Image.FromFile("C:\\DealFX_App\\Images\\Logo.png"); //C:\\DealFX_App\\Images\\Logo.png
                    int height = k.Image.Height;
                    int width = k.Image.Width;
                    e.Graphics.DrawImage(System.Drawing.Image.FromFile("C:\\DealFX_App\\Images\\Logo.png"), leftMargin + 550, yPos, new RectangleF(10, 10, width, height), GraphicsUnit.Pixel);
                    yPos += printFont1.Height + 5;
                }
                catch (Exception ee) { MessageBox.Show("Error in printing"); }

               // yPos += printFont1.Height + 30;
                e.Graphics.DrawString("FOREIGN EXCHANGE INFLOWS/OUTFLOWS", printFontTokenNo, Brushes.Black, leftMargin+20, yPos, new StringFormat());
                yPos += printFont1.Height + 1;

                //e.Graphics.DrawString("I T  S O L U T I O N S", printFont, Brushes.Black, 75, yPos, new StringFormat());
                //yPos += 10;
                yPos += printFont.Height + 5;
                e.Graphics.DrawString("Date : "+ DateTime.Now.ToString("dd/MMM/yyyy"), printFontDate, Brushes.Black, leftMargin +20, yPos, new StringFormat());
                yPos += printFont.Height + 2;



                Graphics gra = this.CreateGraphics();
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;

                //e.Graphics.DrawString(string.Format("{0,-6} {1,6} {2,9}", "Bought","Sold","Swap"), printFontDate, Brushes.Black, leftMargin+50, yPos, new StringFormat());
                //yPos += printFont.Height + 5;

                if (Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Bought"].ToString())==true && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Sold"].ToString())==true && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Sold"].ToString())==true)
                {
                    e.Graphics.DrawString(string.Format("{0,-6} {1,6} {2,9}", "Bought : ✔", "Sold : ✔", "Swap : ✔"), printFontDate, Brushes.Black, leftMargin + 20, yPos, new StringFormat());
                }
                else if (Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Bought"].ToString())==true && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Sold"].ToString())==true && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Sold"].ToString())==false)
                {
                    e.Graphics.DrawString(string.Format("{0,-6} {1,6} {2,9}", "Bought : ✔", "Sold : ✔", "Swap : ✖"), printFontDate, Brushes.Black, leftMargin + 20, yPos, new StringFormat());
                }
                else if (Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Bought"].ToString())==true && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Sold"].ToString())==false && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Sold"].ToString()) == false)
                {
                    e.Graphics.DrawString(string.Format("{0,-6} {1,6} {2,9}", "Bought : ✔", "Sold : ✖", "Swap : ✖"), printFontDate, Brushes.Black, leftMargin + 20, yPos, new StringFormat());
                }
                else if (Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Bought"].ToString()) == false && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Sold"].ToString()) == false && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Sold"].ToString()) == false)
                {
                    e.Graphics.DrawString(string.Format("{0,-6} {1,6} {2,9}", "Bought : ✖", "Sold : ✖", "Swap : ✖"), printFontDate, Brushes.Black, leftMargin + 20, yPos, new StringFormat());
                }
                else if (Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Bought"].ToString()) == true && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Sold"].ToString()) == false && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Sold"].ToString()) == true)
                {
                    e.Graphics.DrawString(string.Format("{0,-6} {1,6} {2,9}", "Bought : ✔", "Sold : ✖", "Swap : ✔"), printFontDate, Brushes.Black, leftMargin + 20, yPos, new StringFormat());
                }
                else if (Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Bought"].ToString()) == false && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Sold"].ToString()) == true && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Sold"].ToString()) == false)
                {
                    e.Graphics.DrawString(string.Format("{0,-6} {1,6} {2,9}", "Bought : ✖", "Sold : ✔", "Swap : ✖"), printFontDate, Brushes.Black, leftMargin + 20, yPos, new StringFormat());
                }
                yPos += printFont1.Height +2;

                if (Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Tod"].ToString())==true && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Tom"].ToString())==true && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Spot"].ToString())==true && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Forward"].ToString())==true)
                {
                    e.Graphics.DrawString(string.Format("{0,-6} {1,6} {2,9} {3,12}", "Tod : ✔", "Tom : ✔", "Spot : ✔", "Forward : ✔"), printFontDate, Brushes.Black, leftMargin + 20, yPos, new StringFormat());
                }
                else if (Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Tod"].ToString())==true && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Tom"].ToString())==true && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Spot"].ToString())==true && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Forward"].ToString()) == false)
                {
                    e.Graphics.DrawString(string.Format("{0,-6} {1,6} {2,9} {3,12}", "Tod : ✔", "Tom : ✔", "Spot : ✔", "Forward : ✖"), printFontDate, Brushes.Black, leftMargin + 20, yPos, new StringFormat());
                }
                else if (Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Tod"].ToString())==true && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Tom"].ToString())==true && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Spot"].ToString()) == false && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Forward"].ToString()) == false)
                {
                    e.Graphics.DrawString(string.Format("{0,-6} {1,6} {2,9} {3,12}", "Tod : ✔", "Tom : ✔", "Spot : ✖", "Forward : ✖"), printFontDate, Brushes.Black, leftMargin + 20, yPos, new StringFormat());
                }
                else if (Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Tod"].ToString())==true && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Tom"].ToString()) == false && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Spot"].ToString()) == false && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Forward"].ToString()) == false)
                {
                    e.Graphics.DrawString(string.Format("{0,-6} {1,6} {2,9} {3,12}", "Tod : ✔", "Tom : ✖", "Spot : ✖", "Forward : ✖"), printFontDate, Brushes.Black, leftMargin + 20, yPos, new StringFormat());
                }
                else if (Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Tod"].ToString()) == false && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Tom"].ToString()) == false && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Spot"].ToString()) == false && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Forward"].ToString()) == false)
                {
                    e.Graphics.DrawString(string.Format("{0,-6} {1,6} {2,9} {3,12}", "Tod : ✖", "Tom : ✖", "Spot : ✖", "Forward : ✖"), printFontDate, Brushes.Black, leftMargin + 20, yPos, new StringFormat());
                }
                else if (Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Tod"].ToString()) == true && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Tom"].ToString()) == false && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Spot"].ToString()) == true && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Forward"].ToString()) == true)
                {
                    e.Graphics.DrawString(string.Format("{0,-6} {1,6} {2,9} {3,12}", "Tod : ✔", "Tom : ✖", "Spot : ✔", "Forward : ✔"), printFontDate, Brushes.Black, leftMargin + 20, yPos, new StringFormat());
                }
                else if (Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Tod"].ToString()) == true && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Tom"].ToString()) == true && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Spot"].ToString()) == false && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Forward"].ToString()) == true)
                {
                    e.Graphics.DrawString(string.Format("{0,-6} {1,6} {2,9} {3,12}", "Tod : ✔", "Tom : ✔", "Spot : ✖", "Forward : ✔"), printFontDate, Brushes.Black, leftMargin + 20, yPos, new StringFormat());
                }
                else if (Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Tod"].ToString()) == true && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Tom"].ToString()) == false && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Spot"].ToString()) == true && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Forward"].ToString()) == false)
                {
                    e.Graphics.DrawString(string.Format("{0,-6} {1,6} {2,9} {3,12}", "Tod : ✔", "Tom : ✖", "Spot : ✔", "Forward : ✖"), printFontDate, Brushes.Black, leftMargin + 20, yPos, new StringFormat());
                }
                else if (Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Tod"].ToString()) == false && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Tom"].ToString()) == true && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Spot"].ToString()) == false && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Forward"].ToString()) == true)
                {
                    e.Graphics.DrawString(string.Format("{0,-6} {1,6} {2,9} {3,12}", "Tod : ✖", "Tom : ✔", "Spot : ✖", "Forward : ✔"), printFontDate, Brushes.Black, leftMargin + 20, yPos, new StringFormat());
                }
                else if (Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Tod"].ToString()) == false && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Tom"].ToString()) == true && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Spot"].ToString()) == true && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Forward"].ToString()) == false)
                {
                    e.Graphics.DrawString(string.Format("{0,-6} {1,6} {2,9} {3,12}", "Tod : ✖", "Tom : ✔", "Spot : ✔", "Forward : ✖"), printFontDate, Brushes.Black, leftMargin + 20, yPos, new StringFormat());
                }
                else if (Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Tod"].ToString()) == true && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Tom"].ToString()) == false && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Spot"].ToString()) == false && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Forward"].ToString()) == true)
                {
                    e.Graphics.DrawString(string.Format("{0,-6} {1,6} {2,9} {3,12}", "Tod : ✔", "Tom : ✖", "Spot : ✖", "Forward : ✔"), printFontDate, Brushes.Black, leftMargin + 20, yPos, new StringFormat());
                }
                else if (Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Tod"].ToString()) == false && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Tom"].ToString()) == false && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Spot"].ToString()) == false && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Forward"].ToString()) == true)
                {
                    e.Graphics.DrawString(string.Format("{0,-6} {1,6} {2,9} {3,12}", "Tod : ✖", "Tom : ✖", "Spot : ✖", "Forward : ✔"), printFontDate, Brushes.Black, leftMargin + 20, yPos, new StringFormat());
                }
                else if (Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Tod"].ToString()) == false && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Tom"].ToString()) == false && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Spot"].ToString()) == true && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Forward"].ToString()) == true)
                {
                    e.Graphics.DrawString(string.Format("{0,-6} {1,6} {2,9} {3,12}", "Tod : ✖", "Tom : ✖", "Spot : ✔", "Forward : ✔"), printFontDate, Brushes.Black, leftMargin + 20, yPos, new StringFormat());
                }
                else if (Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Tod"].ToString()) == false && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Tom"].ToString()) == true && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Spot"].ToString()) == true && Convert.ToBoolean(dsFormCaptions.Tables[0].Rows[0]["Forward"].ToString()) == true)
                {
                    e.Graphics.DrawString(string.Format("{0,-6} {1,6} {2,9} {3,12}", "Tod : ✖", "Tom : ✔", "Spot : ✔", "Forward : ✔"), printFontDate, Brushes.Black, leftMargin + 20, yPos, new StringFormat());
                }
                yPos += printFont1.Height + 1;

                e.Graphics.DrawString(string.Format("{0,-18}", "Serial No :" + dsFormCaptions.Tables[0].Rows[0]["SerialNo"].ToString()), printFontDate, Brushes.Black, leftMargin+550, yPos, new StringFormat());
                yPos += printFontDate.Height + 2;

                e.Graphics.DrawString(string.Format("{0,-18}", "Time      :" + DateTime.Now.ToShortTimeString()), printFontDate, Brushes.Black, leftMargin + 550, yPos, new StringFormat());
                yPos += printFontDate.Height + 2;

                e.Graphics.DrawString("------------------------------------------------------------------------------------------------------", printFontDate, Brushes.Black, leftMargin, yPos, new StringFormat());
                yPos += printFontDate.Height + 1;

                e.Graphics.DrawString(string.Format("{0,-18}","CLIENT :" +dsFormCaptions.Tables[0].Rows[0]["ClientName"].ToString()),printFontDate, Brushes.Black, leftMargin, yPos, new StringFormat());
                yPos += printFontDate.Height + 1;

                e.Graphics.DrawString("------------------------------------------------------------------------------------------------------", printFontDate, Brushes.Black, leftMargin, yPos, new StringFormat());
                yPos += printFontDate.Height + 2;

                e.Graphics.DrawString(string.Format("{0,-6}  {1,6}  {2,13} {3,15}  {4,16}  {5,19}", "CCY(1)Bought", "Amount Bought", "Exchange Rate", "CCY(1)Sold", "Amount Sold", "Value Date"), printFontDate, Brushes.Black, leftMargin, yPos, new StringFormat());
                yPos += printFontDate.Height + 2;

                e.Graphics.DrawString(string.Format("{0,-6}  {1,12} {2,14} {3,17}  {4,18}  {5,22}", dsFormCaptions.Tables[0].Rows[0]["CCYBought"].ToString(), dsFormCaptions.Tables[0].Rows[0]["BoughtAmount"].ToString(), dsFormCaptions.Tables[0].Rows[0]["ExchangeRate"].ToString(), dsFormCaptions.Tables[0].Rows[0]["CCYSold"].ToString(), dsFormCaptions.Tables[0].Rows[0]["SoldAmount"].ToString(),Convert.ToDateTime(dsFormCaptions.Tables[0].Rows[0]["ValueDate"].ToString()).ToShortDateString()), printFontDate, Brushes.Black, leftMargin + 15, yPos, new StringFormat());
                yPos += printFontDate.Height + 2;

                e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------", printFontDate, Brushes.Black, leftMargin, yPos, new StringFormat());
                yPos += printFontDate.Height + 1;

                e.Graphics.DrawString(string.Format("{0,-9} {1,50}", "Receive Through : " + dsFormCaptions.Tables[0].Rows[0]["ReceiveThrough"].ToString(), "Deliver To :" + dsFormCaptions.Tables[0].Rows[0]["DeliverTo"].ToString()), printFontDate, Brushes.Black, leftMargin, yPos, new StringFormat());
                yPos += printFontDate.Height + 2;

                //e.Graphics.DrawString(string.Format("{0,-6} {1,50}", dsFormCaptions.Tables[0].Rows[0]["ReceiveThrough"].ToString(), dsFormCaptions.Tables[0].Rows[0]["DeliverTo"].ToString()), printFontDate, Brushes.Black, leftMargin+15, yPos, new StringFormat());
                //yPos += printFontDate.Height + 2;

                e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------", printFontDate, Brushes.Black, leftMargin, yPos, new StringFormat());
                yPos += printFontDate.Height + 1;

                //e.Graphics.DrawString(string.Format("{0,-9} {1,50}", "DEPOSIT BORROWED", "PLACEMENT"), printFontDate, Brushes.Black, leftMargin, yPos, new StringFormat());
                //yPos += printFontDate.Height + 2;

                //e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------", printFontDate, Brushes.Black, leftMargin, yPos, new StringFormat());
                //yPos += printFontDate.Height + 1;

                //e.Graphics.DrawString(string.Format("{0,-6}  {1,6}  {2,9} {3,10} {4,12}  {5,14}  {6,15} {7,17}", "Rate", "Interest", "Tenor", "Maturity", "Rate", "Interest", "Tenor", "Maturity"), printFontDate, Brushes.Black, leftMargin, yPos, new StringFormat());
                //yPos += printFontDate.Height + 2;

                //e.Graphics.DrawString(string.Format("{0,-6}  {1,5}  {2,9} {3,10} {4,12}  {5,14}  {6,15} {7,17}", dsFormCaptions.Tables[0].Rows[0]["DepositRate"].ToString(), dsFormCaptions.Tables[0].Rows[0]["DepositInterest"].ToString(), dsFormCaptions.Tables[0].Rows[0]["DepositTenor"].ToString(), dsFormCaptions.Tables[0].Rows[0]["DepositMaturity"].ToString(), dsFormCaptions.Tables[0].Rows[0]["PlacementRate"].ToString(), dsFormCaptions.Tables[0].Rows[0]["PlacementInterest"].ToString(), dsFormCaptions.Tables[0].Rows[0]["PlacementTenor"].ToString(), dsFormCaptions.Tables[0].Rows[0]["PlacementMaturity"].ToString()), printFontDate, Brushes.Black, leftMargin + 10, yPos, new StringFormat());
                //yPos += printFontDate.Height + 2;

                e.Graphics.DrawString(string.Format("{0,-18}", "Purpose of Purchase/Sales :" + dsFormCaptions.Tables[0].Rows[0]["PurposePurchaseSale"].ToString()), printFontDate, Brushes.Black, leftMargin, yPos, new StringFormat());
                yPos += printFontDate.Height + 1;


                e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------", printFontDate, Brushes.Black, leftMargin, yPos, new StringFormat());
                yPos += printFontDate.Height + 40;

                //e.Graphics.DrawString(string.Format("{0,-18}{1,6}", "Credit", "Trader"), printFontDate, Brushes.Black, leftMargin + 550, yPos, new StringFormat());
                //yPos += printFontDate.Height + 2;
                
                //e.Graphics.DrawString(string.Format("{0,-18}{1,6}", "Line  ", "_____"), printFontDate, Brushes.Black, leftMargin + 550, yPos, new StringFormat());
                //yPos += printFontDate.Height + 2;
                
                //e.Graphics.DrawString(string.Format("{0,-18}{1,6}", "Clean ", "Trader"), printFontDate, Brushes.Black, leftMargin + 550, yPos, new StringFormat());
                //yPos += printFontDate.Height + 2;
                
                e.Graphics.DrawString(string.Format("{0,-18}", "Sign :____________________"), printFontDate, Brushes.Black, leftMargin + 580, yPos, new StringFormat());
                yPos += printFontDate.Height + 2;
                

                yPos += printFontDate.Height + 2;
                yPos += pen.Width + 4;
                e.Graphics.DrawString(" . ", printFontDate, Brushes.Black, leftMargin, yPos + 50, new StringFormat());
                e.HasMorePages = false;
               
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was some technical technical issue, please contact IT administrator", "IntelligentSafeV2.0-Teller", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new FPException("DealSlipFX.pd_RecieptReport()" + ex.Message.ToString(), FPException.ErrorType.Error);
            }
        }

        private void btnSavePrint_Click(object sender, EventArgs e)
        {
            try
            {
                //bool Result = false;
                _oDealSlipFXMaster = new DealSlipFXMaster();

                _oDealSlipFXMaster.ClientName = txtClientName.Text.ToString().Length > 0 ? txtClientName.Text : null;
                if (txtSerialNo.Text.Length > 0)
                    _oDealSlipFXMaster.SerialNo =Convert.ToInt32(txtSerialNo.Text);
                _oDealSlipFXMaster.CreatedDate = Convert.ToDateTime(txtDate.Text.ToString());
                _oDealSlipFXMaster.Bought = chkBought.Checked;
                _oDealSlipFXMaster.Sold = chkSold.Checked;
                _oDealSlipFXMaster.Swap = chkSwap.Checked;
                _oDealSlipFXMaster.Tod = chkTod.Checked;
                _oDealSlipFXMaster.Tom = chkTom.Checked;
                _oDealSlipFXMaster.Spot = chkSpot.Checked;
                _oDealSlipFXMaster.Forward = chkForward.Checked;
                _oDealSlipFXMaster.Time = txtTime.Text.ToString().Length > 0 ? txtTime.Text : null;
                _oDealSlipFXMaster.CCYBought = txtccyBought.Text.ToString().Length > 0 ? txtccyBought.Text : null;
                if (txtBoughtAmount.Text.Length > 0)
                    _oDealSlipFXMaster.BoughtAmount = Convert.ToDecimal(txtBoughtAmount.Text);
                if (txtExchangeRate.Text.Length > 0)
                    _oDealSlipFXMaster.ExchangeRate = Convert.ToDecimal(txtExchangeRate.Text);
                _oDealSlipFXMaster.CCYSold = txtccySold.Text.ToString().Length > 0 ? txtccySold.Text : null;
                if (txtSoldAmount.Text.Length > 0)
                    _oDealSlipFXMaster.SoldAmount = Convert.ToDecimal(txtSoldAmount.Text);
                _oDealSlipFXMaster.ValueDate = Convert.ToDateTime(dateTimePicker1.Text);
                _oDealSlipFXMaster.ReceiveThrough = txtReceivedThrough.Text.Length > 0 ? txtReceivedThrough.Text : null;
                _oDealSlipFXMaster.DeliverTo = txtDeliverTo.Text.Length > 0 ? txtDeliverTo.Text : null;
                _oDealSlipFXMaster.PurposePurchaseSale = txtPurpose.Text.Length > 0 ? txtPurpose.Text : null;
                if (txtDepositRate.Text.Length > 0)
                    _oDealSlipFXMaster.DepositRate = Convert.ToDecimal(txtDepositRate.Text);
                if (txtDepositInterest.Text.Length > 0)
                    _oDealSlipFXMaster.DepositInterest = Convert.ToDecimal(txtDepositInterest.Text);
                if (txtDepositTenor.Text.Length > 0)
                    _oDealSlipFXMaster.DepositTenor = Convert.ToDecimal(txtDepositTenor.Text);
                if (txtDepositMaturity.Text.Length > 0)
                    _oDealSlipFXMaster.DepositMaturity = Convert.ToDecimal(txtDepositMaturity.Text);
                if (txtPlacementRate.Text.Length > 0)
                    _oDealSlipFXMaster.PlacementRate = Convert.ToDecimal(txtPlacementRate.Text);
                if (txtPlacementInterest.Text.Length > 0)
                    _oDealSlipFXMaster.PlacementInterest = Convert.ToDecimal(txtPlacementInterest.Text);
                if (txtPlacementTenor.Text.Length > 0)
                    _oDealSlipFXMaster.PlacementTenor = Convert.ToDecimal(txtPlacementTenor.Text);
                if (txtPlacementMaturity.Text.Length > 0)
                    _oDealSlipFXMaster.PlacementMaturity = Convert.ToDecimal(txtPlacementMaturity.Text);

                int Result = _oDealSlipFXMaster.AddDealSlipFXDetails();

                if (Result > 0)
                {
                    MessageBox.Show("Receipt added successfully.", "Electronic Receipt ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _oDealSlipFXMaster.UpdateSerialNo();
                    dsFormCaptions = new DataSet();
                    _oDealSlipFXMaster.DealSlipFXId = Result;
                    dsFormCaptions = _oDealSlipFXMaster.GetReceiptByID();
                    PrintRecipt();
                    ClearText();
                    BindData();
                }
                else
                {
                    MessageBox.Show("Receipt not added successfully.", "Electronic Receipt ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("There was some issue,Please kindly contact IT Administrator", "Electronic Receipt ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new FPException("DealSlipFX.btnSavePrint_Click()" + ex.Message.ToString(), FPException.ErrorType.Error);

            }
        }
    }
}
