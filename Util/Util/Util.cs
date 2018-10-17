using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using System.Windows.Forms;

using Newtonsoft.Json.Linq;
using System.Globalization;

namespace Util
{
    public static class Util
    {
        //constantes
        public const String constNewItemTextGrid = "Click para agregar un nuevo elemento";

        public enum FormatType
        {
            Numerico,
            MonedaLocal,
            MonedaExtrangera,
            FechaCorta,
            FechaLarga,
            TiempoCorto,
            TiempoLargo,
            FechaCompletaTiempoCorto,
            FechaCompletaTiempoLargo,
            FechaGeneralTiempoCorto,
            FechaGeneralTiempoLargo,
            MesDia,
            AnoMes,
            Porcentaje,
            Personalizado
        }


        public static String LocalSimbolCurrency { get; set; }
        public static String ForeingSimbolCurrency { get; set; }
        public static int DecimalLenght { get; set; }

        public static void LocalCurrency(object sender, ConvertEventArgs cevent)
        {
            // The method converts only to string type. Test this using the DesiredType.
            if ((cevent.DesiredType != typeof(string)) || cevent.Value == null) return;
            NumberFormatInfo nfi = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
            nfi.CurrencySymbol = LocalSimbolCurrency;
            // Use the ToString method to format the value as currency ("c").
            cevent.Value = ((decimal)cevent.Value).ToString("c" + DecimalLenght, nfi);

        }

        public static void ForeingCurrency(object sender, ConvertEventArgs cevent)
        {
            // The method converts only to string type. Test this using the DesiredType.

            if (cevent.DesiredType != typeof(string) || cevent.Value == null) return;
            NumberFormatInfo nfi = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
            nfi.CurrencySymbol = ForeingSimbolCurrency;
            // Use the ToString method to format the value as currency ("c").
            cevent.Value = ((decimal)cevent.Value).ToString("c" + DecimalLenght, nfi);

        }

        public static void SetFormatDateTextEdit(TextEdit Caja) {
            Caja.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            Caja.Properties.Mask.EditMask = "([012]?[1-9]|[123]0|31)/(0?[1-9]|1[012])/([123][0-9])?[0-9][0-9]";
        }

        public static void SetFormatTextEditGrid(RepositoryItemTextEdit texto, FormatType typeFormat, String Mask = "")
        {
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");
            switch (typeFormat)
            {
                case FormatType.Numerico:
                    texto.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    texto.Mask.EditMask = "n" + DecimalLenght;
                    texto.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                    break;
                case FormatType.MonedaExtrangera:

                    ci.NumberFormat.CurrencySymbol = ForeingSimbolCurrency.Trim() +  " ";
                    texto.Mask.Culture = ci;
                    texto.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    texto.Mask.EditMask = "c" + DecimalLenght;
                    texto.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                    break;
                case FormatType.MonedaLocal:

                    ci.NumberFormat.CurrencySymbol = LocalSimbolCurrency.Trim() +  " ";
                    texto.Mask.Culture = ci;
                    texto.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    texto.Mask.EditMask = "c" + DecimalLenght;//string.Format("#,###,###,##0.00", Config.LocalSimbolCurrency);
                    texto.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

                    break;
                case FormatType.FechaCorta:
                    texto.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                    texto.Mask.EditMask = "d";
                    break;
                case FormatType.FechaLarga:
                    texto.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                    texto.Mask.EditMask = "D";
                    break;
                case FormatType.TiempoCorto:
                    texto.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                    texto.Mask.EditMask = "t";
                    break;
                case FormatType.TiempoLargo:
                    texto.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                    texto.Mask.EditMask = "T";
                    break;
                case FormatType.FechaGeneralTiempoCorto:
                    texto.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                    texto.Mask.EditMask = "g";
                    break;
                case FormatType.FechaGeneralTiempoLargo:
                    texto.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                    texto.Mask.EditMask = "G";
                    break;
                case FormatType.MesDia:
                    texto.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                    texto.Mask.EditMask = "m";
                    break;
                case FormatType.AnoMes:
                    texto.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                    texto.Mask.EditMask = "y";
                    break;
                case FormatType.Porcentaje:
                    texto.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    texto.Mask.EditMask = "p";
                    break;
                case FormatType.Personalizado:
                    texto.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Custom;
                    texto.Mask.EditMask = Mask;
                    break;
            }
            texto.Mask.UseMaskAsDisplayFormat = true;
        }

        public static void SetFormatTextEdit(TextEdit texto, FormatType typeFormat, String Mask = "")
        {
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");
            switch (typeFormat)
            {
                case FormatType.Numerico:
                    texto.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    texto.Properties.Mask.EditMask = "n" + DecimalLenght;
                    texto.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                    break;
                case FormatType.MonedaExtrangera:

                    ci.NumberFormat.CurrencySymbol = ForeingSimbolCurrency.Trim() + " ";
                    texto.Properties.Mask.Culture = ci;
                    texto.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    texto.Properties.Mask.EditMask = "c" + DecimalLenght;
                    texto.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                    break;
                case FormatType.MonedaLocal:

                    ci.NumberFormat.CurrencySymbol = LocalSimbolCurrency.Trim() + " ";
                    texto.Properties.Mask.Culture = ci;
                    texto.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    texto.Properties.Mask.EditMask = "c" + DecimalLenght;//string.Format("#,###,###,##0.00", Config.LocalSimbolCurrency);
                    texto.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

                    break;
                case FormatType.FechaCorta:
                    texto.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                    texto.Properties.Mask.EditMask = "d";
                    break;
                case FormatType.FechaLarga:
                    texto.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                    texto.Properties.Mask.EditMask = "D";
                    break;
                case FormatType.TiempoCorto:
                    texto.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                    texto.Properties.Mask.EditMask = "t";
                    break;
                case FormatType.TiempoLargo:
                    texto.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                    texto.Properties.Mask.EditMask = "T";
                    break;
                case FormatType.FechaGeneralTiempoCorto:
                    texto.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                    texto.Properties.Mask.EditMask = "g";
                    break;
                case FormatType.FechaGeneralTiempoLargo:
                    texto.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                    texto.Properties.Mask.EditMask = "G";
                    break;
                case FormatType.MesDia:
                    texto.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                    texto.Properties.Mask.EditMask = "m";
                    break;
                case FormatType.AnoMes:
                    texto.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                    texto.Properties.Mask.EditMask = "y";
                    break;
                case FormatType.Porcentaje:
                    texto.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    texto.Properties.Mask.EditMask = "p";
                    break;
                case FormatType.Personalizado:
                    texto.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Custom;
                    texto.Properties.Mask.EditMask = Mask;
                    break;
            }
            texto.Properties.Mask.UseMaskAsDisplayFormat = true;
        }


        public static void ConfigLookupEdit(SearchLookUpEdit lkupControl, Object DataSource,
                                         String DisplayMember, String ValueMember, int WinPopupWidth = 250, int WinPopupHeigth = 200)
        {
            lkupControl.Properties.DataSource = DataSource;
            lkupControl.Properties.PopupFormSize = new Size(WinPopupWidth, WinPopupHeigth);
            lkupControl.Properties.ShowClearButton = false;
            lkupControl.Properties.DisplayMember = DisplayMember;
            lkupControl.Properties.ValueMember = ValueMember;
            lkupControl.Properties.NullText = "--- ---";
            lkupControl.Properties.View.BestFitColumns();
            lkupControl.Properties.NullValuePrompt = "--- ---";
            lkupControl.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
        }

        public static void ConfigLookupEditSetViewColumns(SearchLookUpEdit lkupControl, String Columns)
        {
            dynamic oColumns = JArray.Parse(Columns);
            DevExpress.XtraGrid.Views.Grid.GridView lookupView = lkupControl.Properties.View; //new DevExpress.XtraGrid.Views.Grid.GridView();
            bool AutoWidth = false;
            int count = 0;
            lookupView.Columns.Clear();
            foreach (dynamic ele in oColumns)
            {
                DevExpress.XtraGrid.Columns.GridColumn col = new DevExpress.XtraGrid.Columns.GridColumn();
                col.Caption = ele.ColumnCaption;
                col.FieldName = ele.ColumnField;
                col.MinWidth = 10;
                col.Visible = true;
                col.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                col.VisibleIndex = count;

                if (ele.width != null)
                    col.Width = Convert.ToInt32(((Convert.ToDouble(lkupControl.Properties.PopupFormSize.Width) - 27) * Convert.ToDouble(ele.width)) / 100);
                else
                    AutoWidth = true;

                col.OptionsColumn.AllowSize = true;

                lookupView.Columns.Add(col);

                count++;
            }

            lookupView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            lookupView.OptionsLayout.StoreAllOptions = true;
            lookupView.BestFitMaxRowCount = -1;
            lookupView.OptionsFilter.ColumnFilterPopupRowCount = 10;
            lookupView.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText;
            lookupView.OptionsFind.FindDelay = 100;
            lookupView.OptionsFind.SearchInPreview = true;
            lookupView.OptionsView.ColumnAutoWidth = AutoWidth;
            lookupView.OptionsFind.ShowClearButton = false;
            lookupView.OptionsLayout.Columns.AddNewColumns = false;
            lookupView.OptionsSelection.EnableAppearanceFocusedCell = false;
            lookupView.OptionsView.ShowGroupPanel = false;
            lkupControl.Properties.View = lookupView;
        }


        public static Control FindControl(this Control root, string text)
        {
            if (root == null) throw new ArgumentNullException("root");
            foreach (Control child in root.Controls)
            {
                if (child.Text == text) return child;
                Control found = FindControl(child, text);
                if (found != null) return found;
            }
            return null;
        }


        public static void SetDefaultBehaviorControls(DevExpress.XtraGrid.Views.Grid.GridView pGridView, bool pEditable,
                                                            DevExpress.XtraGrid.GridControl pGrid,
                                                                     //DevExpress.XtraBars.Bar pBar,
                                                  // DevExpress.XtraEditors.LabelControl plblTitulo,
                                                 //DevExpress.XtraEditors.PanelControl pPanelTitulo,
                                                                            String _tituloVentana,
                                                                   System.Windows.Forms.Form pForm)
        {
            //Grid
            pGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            pGridView.OptionsBehavior.Editable = pEditable;
            pGridView.OptionsSelection.EnableAppearanceFocusedRow = true;
            pGridView.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.TextAndVisual;
            pGridView.OptionsView.ShowAutoFilterRow = true;
            //Navegador
            if (pGrid != null)
            {
                pGrid.EmbeddedNavigator.Buttons.Append.Enabled = false;
                pGrid.EmbeddedNavigator.Buttons.Append.Visible = false;

                pGrid.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
                pGrid.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;

                pGrid.EmbeddedNavigator.Buttons.Remove.Enabled = false;
                pGrid.EmbeddedNavigator.Buttons.Remove.Visible = false;

                pGrid.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
                pGrid.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
                pGrid.EmbeddedNavigator.Enabled = true;
            }
            //Barra Prinicpal
            //pBar.OptionsBar.AllowQuickCustomization = false;

            //titulo
            //plblTitulo.Font = new Font(plblTitulo.Font.FontFamily, 12f, FontStyle.Bold);
            //plblTitulo.Size = new Size(pPanelTitulo.Size.Width / 2, pPanelTitulo.Size.Height / 2);
            //plblTitulo.Top = (pPanelTitulo.Height / 2) - (plblTitulo.Height / 2);
            //plblTitulo.Left = (pPanelTitulo.Width / 2) - (plblTitulo.Width / 2);
            //plblTitulo.ForeColor = Color.DodgerBlue;
            //plblTitulo.Text = _tituloVentana;

            ////Titulo e Icono de la ventana
            pForm.Text = _tituloVentana;
           // pForm.Icon = Properties.Resources.Icon1;


        }
    }
}
