using System;
using System.Collections.Generic;
using System.Text;
using FP.BL.DealSlipFX;
using FP.DAL.SQL;
using FP.Common.ExceptionLogging;
using System.Data;


namespace FP.BL.DealSlipFX
{
    public class DealSlipFXMaster
    {
        DBUtility objDBUtility=null;


        #region Variables
            private int iDealSlipFXId;
            private string sClientName;
            private int iSerialNo;
            private DateTime dCreatedDate;
            private bool bBought;
            private bool bSold;
            private bool bSwap;
            private bool bTod;
            private bool bTom;
            private bool bSpot;
            private bool bForward;
            private string sTime;
            private string sCCYBought;
            private decimal dBoughtAmount;
            private decimal dExchangeRate;
            private string sCCYSold;
            private decimal dSoldAmount;
            private DateTime dValueDate;
            private string sReceiveThrough;
            private string sDeliverTo;
            private string sPurposePurchaseSale;
            private decimal dDepositRate;
            private decimal dDepositInterest;
            private decimal dDepositTenor;
            private decimal dDepositMaturity;
            private decimal dPlacementRate;
            private decimal dPlacementInterest;
            private decimal dPlacementTenor;
            private decimal dPlacementMaturity;    
        #endregion

        #region Properties
            public int DealSlipFXId { get { return iDealSlipFXId; } set { iDealSlipFXId=value;} }
            public string ClientName { get { return sClientName; } set { sClientName=value;} }
            public int SerialNo { get { return iSerialNo; } set { iSerialNo=value;} }
            public DateTime CreatedDate { get { return dCreatedDate; } set { dCreatedDate=value;} }
            public bool Bought { get { return bBought; } set { bBought=value;} }
            public bool Sold { get { return bSold; } set { bSold=value;} }
            public bool Swap { get { return bSwap; } set { bSwap=value;} }
            public bool Tod { get { return bTod; } set { bTod=value;} }
            public bool Tom { get { return bTom; } set { bTom=value;} }
            public bool Spot { get { return bSpot; } set { bSpot=value;} }
            public bool Forward { get { return bForward; } set { bForward=value;} }
            public string Time { get { return sTime; } set { sTime=value;} }
            public string CCYBought { get { return sCCYBought; } set { sCCYBought=value;} }
            public decimal BoughtAmount { get { return dBoughtAmount; } set { dBoughtAmount=value;} }
            public decimal ExchangeRate { get { return dExchangeRate; } set { dExchangeRate=value;} }
            public string CCYSold { get { return sCCYSold; } set { sCCYSold=value;} }
            public decimal SoldAmount { get { return dSoldAmount; } set { dSoldAmount=value;} }
            public DateTime ValueDate { get { return dValueDate; } set { dValueDate=value;} }
            public string ReceiveThrough { get { return sReceiveThrough; } set { sReceiveThrough=value;} }
            public string DeliverTo { get { return sDeliverTo;} set{sDeliverTo=value;} }
            public string PurposePurchaseSale { get { return sPurposePurchaseSale; } set { sPurposePurchaseSale=value;} }
            public decimal DepositRate { get { return dDepositRate; } set { dDepositRate=value;} }
            public decimal DepositInterest { get { return dDepositInterest; } set { dDepositInterest = value; } }
            public decimal DepositTenor { get { return dDepositTenor; } set { dDepositTenor = value; } }
            public decimal DepositMaturity { get { return dDepositMaturity; } set { dDepositMaturity = value; } }
            public decimal PlacementRate { get { return dPlacementRate; } set { dPlacementRate = value; } }
            public decimal PlacementInterest { get { return dPlacementInterest; } set { dPlacementInterest = value; } }
            public decimal PlacementTenor { get { return dPlacementTenor; } set { dPlacementTenor = value; } }
            public decimal PlacementMaturity { get { return dPlacementMaturity; } set { dPlacementMaturity = value; } }
        #endregion

        #region Methods

            public int AddDealSlipFXDetails()
            {
                try
                {
                    bool _bresult = false;
                    int DealSlipFX =0;
                    objDBUtility = new DBUtility();

                    objDBUtility.AddParameters("@ClientName", DBUtilDBType.Varchar, DBUtilDirection.In, 100, sClientName);
                    objDBUtility.AddParameters("@SerialNo", DBUtilDBType.Integer, DBUtilDirection.In, 100, iSerialNo);
                    if(dCreatedDate!=DateTime.MinValue)
                    objDBUtility.AddParameters("@CreatedDate", DBUtilDBType.DateTime, DBUtilDirection.In, 12, dCreatedDate);
                    objDBUtility.AddParameters("@Bought", DBUtilDBType.Boolean, DBUtilDirection.In, 5, bBought);
                    objDBUtility.AddParameters("@Sold", DBUtilDBType.Boolean, DBUtilDirection.In, 5, bSold);
                    objDBUtility.AddParameters("@Swap", DBUtilDBType.Boolean, DBUtilDirection.In, 5, bSwap);
                    objDBUtility.AddParameters("@Tod", DBUtilDBType.Boolean, DBUtilDirection.In, 5, bTod);
                    objDBUtility.AddParameters("@Tom", DBUtilDBType.Boolean, DBUtilDirection.In, 5, bTom);
                    objDBUtility.AddParameters("@Spot", DBUtilDBType.Boolean, DBUtilDirection.In, 5, bSpot);
                    objDBUtility.AddParameters("@Forward", DBUtilDBType.Boolean, DBUtilDirection.In, 7, bForward);
                    objDBUtility.AddParameters("@Time", DBUtilDBType.Varchar, DBUtilDirection.In, 20, sTime);
                    objDBUtility.AddParameters("@CCYBought", DBUtilDBType.Varchar, DBUtilDirection.In, 50, sCCYBought);
                    objDBUtility.AddParameters("@BoughtAmount", DBUtilDBType.Decimal, DBUtilDirection.In, 20, dBoughtAmount);
                    objDBUtility.AddParameters("@ExchangeRate", DBUtilDBType.Decimal, DBUtilDirection.In, 20, dExchangeRate);
                    objDBUtility.AddParameters("@CCYSold", DBUtilDBType.Varchar, DBUtilDirection.In, 50,sCCYSold);
                    objDBUtility.AddParameters("@SoldAmount", DBUtilDBType.Decimal, DBUtilDirection.In, 20, dSoldAmount);
                    if (dValueDate != DateTime.MinValue)
                    objDBUtility.AddParameters("@ValueDate", DBUtilDBType.DateTime, DBUtilDirection.In, 14, dValueDate);
                    objDBUtility.AddParameters("@ReceiveThrough", DBUtilDBType.Varchar, DBUtilDirection.In, 50, sReceiveThrough);
                    objDBUtility.AddParameters("@DeliverTo", DBUtilDBType.Varchar, DBUtilDirection.In, 50, sDeliverTo);
                    objDBUtility.AddParameters("@PurposePurchaseSale", DBUtilDBType.Varchar, DBUtilDirection.In, 250, sPurposePurchaseSale);
                    objDBUtility.AddParameters("@DepositRate", DBUtilDBType.Decimal, DBUtilDirection.In, 20, dDepositRate);
                    objDBUtility.AddParameters("@DepositInterest", DBUtilDBType.Decimal, DBUtilDirection.In, 20, dDepositInterest);
                    objDBUtility.AddParameters("@DepositTenor", DBUtilDBType.Decimal, DBUtilDirection.In, 20, dDepositTenor);
                    objDBUtility.AddParameters("@DepositMaturity", DBUtilDBType.Decimal, DBUtilDirection.In, 20, dDepositMaturity);
                    objDBUtility.AddParameters("@PlacementRate", DBUtilDBType.Decimal, DBUtilDirection.In, 20, dPlacementRate);
                    objDBUtility.AddParameters("@PlacementInterest", DBUtilDBType.Decimal, DBUtilDirection.In, 20, dPlacementInterest);
                    objDBUtility.AddParameters("@PlacementTenor", DBUtilDBType.Decimal, DBUtilDirection.In, 20, dPlacementTenor);
                    objDBUtility.AddParameters("@PlacementMaturity", DBUtilDBType.Decimal, DBUtilDirection.In, 20, dPlacementMaturity);
                    objDBUtility.AddParameters("@DealSlipFXId", DBUtilDBType.Integer, DBUtilDirection.Out, 20, iDealSlipFXId);
                     objDBUtility.Execute_StoreProc("USP_ADD_DEAL_SLIP_FX_DETAILS");
                     DealSlipFX = Convert.ToInt32(objDBUtility.getOutputParameterValue("@DealSlipFXId"));
                    
                    return DealSlipFX;
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                        throw new FPException("FP.BL.DealSlipFX.DealSlipFXMaster.AddDealSlipFXDetails()" + ex.InnerException.ToString(), FPException.ErrorType.Error);
                    else
                        throw new FPException("FP.BL.DealSlipFX.DealSlipFXMaster.AddDealSlipFXDetails()" + ex.Message.ToString(), FPException.ErrorType.Error);
                }
            }

            public DataSet GetReceiptByID()
            {

                try
                {
                    DBUtility oDBUtility = new DBUtility();

                    oDBUtility.AddParameters("@DealSlipFXId", DBUtilDBType.Integer, DBUtilDirection.In, 10, iDealSlipFXId);

                    DataSet ds = oDBUtility.Execute_StoreProc_DataSet("USP_GET_DEAL_SLIP_FX_DETAILS_BYID");
                    return ds;
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                        throw new FPException("FP.BL.DealSlipFX.DealSlipFXMaster.GetReceiptByID()" + ex.InnerException.ToString(), FPException.ErrorType.Error);
                    else
                        throw new FPException("FP.BL.DealSlipFX.DealSlipFXMaster.GetReceiptByID()" + ex.InnerException.ToString(), FPException.ErrorType.Error);
                }
            }

            public DataSet GetSerialNo()
            {

                try
                {
                    DBUtility oDBUtility = new DBUtility();
                    DataSet ds = oDBUtility.Execute_StoreProc_DataSet("USP_GET_SERIAL_NO");
                    return ds;
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                        throw new FPException("FP.BL.DealSlipFX.DealSlipFXMaster.GetSerialNo()" + ex.InnerException.ToString(), FPException.ErrorType.Error);
                    else
                        throw new FPException("FP.BL.DealSlipFX.DealSlipFXMaster.GetSerialNo()" + ex.InnerException.ToString(), FPException.ErrorType.Error);
                }
            }

            public bool UpdateSerialNo()
            {
                try
                {
                    bool _bresult = false;
                    
                    objDBUtility = new DBUtility();

                    objDBUtility.AddParameters("@SerialNo", DBUtilDBType.Integer, DBUtilDirection.In, 10, iSerialNo);
                    _bresult = objDBUtility.Execute_StoreProc("USP_UPDATE_SERIAL_NO");
                    return _bresult;
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                        throw new FPException("FP.BL.DealSlipFX.DealSlipFXMaster.UpdateSerialNo()" + ex.InnerException.ToString(), FPException.ErrorType.Error);
                    else
                        throw new FPException("FP.BL.DealSlipFX.DealSlipFXMaster.UpdateSerialNo()" + ex.Message.ToString(), FPException.ErrorType.Error);
                }
            }


        #endregion
    }
}
