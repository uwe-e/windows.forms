using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace BSE.Charts
{
    internal class ChartItemCollectionEditor : CollectionEditor
    {
        #region FieldsPrivate

		private CollectionForm m_collectionForm;
        private ChartItemColors m_chartItemColors;

		#endregion

		#region MethodsPublic

        public ChartItemCollectionEditor(Type type) : base(type)
		{
        }

        //public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        //{
        //    System.Windows.Forms.MessageBox.Show("jetzt 0");
        //    if (this.m_collectionForm != null && this.m_collectionForm.Visible)
        //    {
        //        ChartItemCollectionEditor editor = new ChartItemCollectionEditor(this.CollectionType);
        //        return editor.EditValue(context, provider, value);
        //    }
        //    else
        //    {
        //        return base.EditValue(context, provider, value);
        //    }
        //}

        #endregion

        #region MethodsProtected

        protected override CollectionForm CreateCollectionForm()
        {
            this.m_collectionForm = base.CreateCollectionForm();
            this.m_chartItemColors = new ChartItemColors();
            return this.m_collectionForm;
        }

        protected override Object CreateInstance(Type ItemType)
        {
            /* you can create the new instance yourself 
                 * ComplexItem ci=new ComplexItem(2,"ComplexItem",null);
                 * we know for sure that the itemType it will always be ComplexItem
                 *but this time let it to do the job... 
                 */
            ChartItem chartItem = (ChartItem)base.CreateInstance(ItemType);
            if (this.Context.Instance != null)
            {
                if (this.Context.Instance is IIndex)
                {
                    chartItem.Index = ((IIndex)this.Context.Instance).GetIndex();
                    chartItem.Color = this.m_chartItemColors.GetColor(chartItem.Index);
                }
            }
            return chartItem;
        }

        #endregion
    }
}
