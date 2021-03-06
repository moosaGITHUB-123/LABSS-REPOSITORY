﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using DevExpress.Xpf.Layout;
using DevExpress.Xpf.LayoutControl;
using POS.DBClasses;
using System.Collections.ObjectModel;
using DevExpress;
using DevExpress.Xpf.Charts;
using DevExpress.Xpf;
using DevExpress.Xpf.Docking;
using DevExpress.Xpf.Core;
using System.Xaml;
using DevExpress.Xpf.Editors;
using DevExpress.XtraEditors;
using DevExpress.Xpf.DocumentViewer;



namespace POS
{
    /// <summary>
    /// Interaction logic for WindowProductModifier.xaml
    /// </summary>
    public partial class WindowProductModifier : Window
    {
        public WindowProductModifier()
        {
            InitializeComponent();
        }

        //public string ComboValue { get; private set; }
        //public string ComboValue2 { get; private set; }
        //public int ID { get; private set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int SpTypeChanger = 1; SpTypeChanger <= 14; SpTypeChanger++)
            {

                
                DataTable dt = EntityDBClass.Select("spProductComboBoxLoad", new string[] { "@Type" }, new string[] { SpTypeChanger.ToString() });

                //----------------------------------------//
                if (SpTypeChanger == 1)
                {
                    CboBrand.ItemsSource = dt;
                }
                if (SpTypeChanger == 2)
                {
                    CboFlavour.ItemsSource = dt;
                }
                if (SpTypeChanger == 3)
                {
                    CboSize.ItemsSource = dt;
                }
                if (SpTypeChanger == 4)
                {
                    CboShape.ItemsSource = dt;
                }
                if (SpTypeChanger == 5)
                {
                    //CboArticle.ItemsSource = dt;
                }
                if (SpTypeChanger == 6)
                {
                   // CboDesign.ItemsSource = dt;
                }
                if (SpTypeChanger == 7)
                {
                 //   CboPublisher.ItemsSource = dt;
                }
                if (SpTypeChanger == 8)
                {
                //    CboFlavour.ItemsSource = dt;
                }
                if (SpTypeChanger == 9)
                {
                    CboPackaging.ItemsSource = dt;
                }
                if (SpTypeChanger == 10)
                {
                    CboAddtChrgsType.ItemsSource = dt;
                }
                if (SpTypeChanger == 11)
                {
                    CboTaxCategory.ItemsSource = dt;
                }
                if (SpTypeChanger == 12)
                {
                    CboAddtTaxChrgsType.ItemsSource = dt;
                }
                if (SpTypeChanger == 13)
                {
                 //   CboFlavour.ItemsSource = dt;
                }
               
                //------------ Combo Restarter Above ----------//

            }

        }

        private void BtnProductSave_Click(object sender, RoutedEventArgs e)
        {
            //////   Product Data Saving Process   //////////
            try
            {



                DataTable dt = EntityDBClass.Select("spProduct", new string[]
                                                    {
                                                            "@Type" ,
                                                            "@ProductCategoryID" ,
                                                            "@ProductFullName" ,
                                                            "@ProductShortName" ,
                                                            "@ProductImage1Path" ,
                                                            "@ProductBarcode" ,
                                                            "@ProductAlternateBarcode" ,
                                                            "@ProductColorID",
                                                            "@ProductSaleRate" ,
                                                            "@ProductCostRate" ,
                                                            "@ProductIsAllowDecimalSale" ,
                                                            "@ProductMRP" ,
                                                            "@ProductWholeSaleRate" ,
                                                            "@ProductGSMamount" ,
                                                            "@ProductAdditionalChargesID" ,
                                                            "@ProductAdditionalChargesAmount" ,
                                                            "@ProductMaxDiscPercentage" ,
                                                            "@ProductMaxDiscAmount" ,
                                                            "@ProductIsOrderAble" ,
                                                            "@ProductProductionRate" ,
                                                            "@ProductTaxCategoryID" ,
                                                            "@ProductTaxPercentage" ,
                                                            "@ProductTaxAmount" ,
                                                            "@ProductAdditionalTaxID" ,
                                                            "@ProductAdditionalTaxAmount" ,
                                                            "@ProductHSCode" ,
                                                            "@ProductBrandID" ,
                                                            "@ProductBrandName" ,
                                                            "@ProductFlavourID" ,
                                                            "@ProductFlavourName" ,
                                                            "@ProductSizeID" ,
                                                            "@ProductSizeName" ,
                                                            "@ProductShapeID" ,
                                                            "@ProductShapeName" ,
                                                            "@ProductArticleID",
                                                            "@ProductArticleName" ,
                                                            "@ProductIsInventoriable" ,
                                                            "@ProductRegularDiscardAble" ,
                                                            "@ProductIsReturnAble" ,
                                                            "@ProductIsExchangeAble" ,
                                                            "@ProductExpiryDays" ,
                                                            "@ProductDefaultWeight" ,
                                                            "@ProductSizeInNumber" ,
                                                            "@ProductDesignID" ,
                                                            "@ProductDesignName",
                                                            "@ProductRelatedIds" ,
                                                            "@ProductSeriesID" ,
                                                            "@RegionID" ,
                                                            "@ProductPackagingID" ,
                                                            "@ProductDescrpition" ,
                                                            "@recordStatusID" ,
                                                            "@recordStatusCause" ,
                                                            "@recordLastModifiedBy" ,
                                                            "@recordLastModifiedDate" ,
                                                            "@recordEntryBy" ,
                                                            "@recordEntryDate"
                                                    }, new string[] {

                                                    "1",
                                                    "1",
                                                    txtFullName.Text,
                                                    txtShortName.Text,
                                                    "Path not exist", ///---> need to send product image path
                                                    txtBarcode.Text,
                                                    txtAltBarcode.Text,
                                                    "0",             // ----> Color ID here goes
                                                    txtSaleRate.Text==""?"0":txtSaleRate.Text,
                                                    txtCostRate.Text==""?"0":txtCostRate.Text,
                                           "False" ,//ToggDecimalSale.ActualCheckedStateContent.ToString(),
                                                    txtMRP.Text==""?"0":txtMRP.Text,
                                                    txtWSRate.Text==""?"0":txtWSRate.Text,
                                                    txtExtraGSM.Text==""?"0":txtExtraGSM.Text,
                                                    (CboAddtChrgsType.SelectedItemValue??0).ToString(),
                                                    txtAddtChrgsAmount.Text==""?"0":txtAddtChrgsAmount.Text,
                                                    txtMaxDiscPercentage.Text==""?"0":txtMaxDiscPercentage.Text,
                                                    txtMaxDiscAmount.Text==""?"0":txtMaxDiscAmount.Text,
                                            "True" ,//ToggOrderAble.ActualCheckedStateContent.ToString(),
                                                    txtProductionChrgs.Text==""?"0":txtProductionChrgs.Text,
                                                    (CboTaxCategory.SelectedItemValue??0).ToString(),
                                                    txtTaxPercentage.Text==""?"0":txtTaxPercentage.Text,
                                                    txtTaxAmount.Text==""?"0":txtTaxAmount.Text,
                                                    (CboAddtTaxChrgsType.SelectedItemValue??0).ToString(),
                                                    txtAddtTaxChrgsAmount.Text==""?"0":txtAddtTaxChrgsAmount.Text,
                                                    txtHSCode.Text,
                                                    (CboBrand.SelectedItemValue??0).ToString(),
                                                    CboBrand.Text,
                                                    (CboFlavour.SelectedItemValue??0).ToString(),
                                                    CboFlavour.Text,
                                                    (CboSize.SelectedItemValue??0).ToString(),
                                                    CboSize.Text,
                                                    (CboShape.SelectedItemValue??0).ToString(),
                                                    CboShape.Text,
                                                    "0",  // Article ID
                                                    txtArticleNum.Text,
                                            "True", //toggInventoriable.ActualCheckedStateContent.ToString(),
                                           "False", //toggRegularDiscard.ActualCheckedStateContent.ToString(),
                                            "True", //toggReturnAble.ActualCheckedStateContent.ToString(),
                                            "True", //toggExchangeAble.ActualCheckedStateContent.ToString(),
                                                    txtExpiryPeriod.Text==""?"0":txtExpiryPeriod.Text,
                                                    txtDefaultWeight.Text==""?"0":txtDefaultWeight.Text,
                                                    txtSizeNum.Text,
                                                    (CboDesign.SelectedItemValue??0).ToString(),
                                                    CboDesign.Text.ToString(),
                                                    txtRelativeID.Text,
                                                    (CboSeries.SelectedItemValue??0).ToString(),
                                                    (CboRegion.SelectedItemValue??0).ToString(),
                                                    (CboPackaging.SelectedItemValue??0).ToString(),
                                                    txtProductDetails.Text,
                                                    (CboRecordStatus.SelectedItemValue??0).ToString(),
                                                    txtRecordStatus.Text,
                                                    "0",
                                                    DateTime.Now.ToString() ,
                                                    "0" ,  ///---- User id will sent here
                                                     DateTime.Now.ToString()
                                                    }
                                                    
                                                    );

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnImgBrowse_Click(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();

            Nullable<bool> result = openFileDlg.ShowDialog();

            if (result == true)
            {

                string SelectedProductImgPath = openFileDlg.FileName;
                // TextBlock1.Text = System.IO.File.ReadAllText(openFileDlg.FileName);
                //  ProductImage.Source = open.FileName;
                string ImageName = openFileDlg.FileName;
                ProductImage.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(ImageName);

            }

        }
    }
}
