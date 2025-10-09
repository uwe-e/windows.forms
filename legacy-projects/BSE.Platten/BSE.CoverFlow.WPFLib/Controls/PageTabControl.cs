using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Collections.Specialized;
using System.Windows.Controls.Primitives;

namespace BSE.CoverFlow.WPFLib.Controls
{
    //public class CacheableTabControl
    /// <summary>
    /// The standard WPF TabControl is quite bad in the fact that it only
    /// even contains the current TabItem in the VisualTree, so if you
    /// have complex views it takes a while to re-create the view each tab
    /// selection change.Which makes the standard TabControl very sticky to
    /// work with. This class along with its associated ControlTemplate
    /// allow all TabItems to remain in the VisualTree without it being Sticky.
    /// It does this by keeping all TabItem content in the VisualTree but
    /// hides all inactive TabItem content, and only keeps the active TabItem
    /// content shown.
    /// </summary>
    [TemplatePart(Name = "PART_ItemsHolder", Type = typeof(Panel))]
    public class PageTabControl : TabControl
    {
        #region FieldsPrivate
        private Panel m_itemsHolderPanel = null;
        #endregion

        #region MethodsPublic
        public PageTabControl()
            : base()
        {
            // this is necessary so that we get the initial databound selected item
            this.ItemContainerGenerator.StatusChanged += ItemContainerGenerator_StatusChanged;
            this.Loaded += OnLoaded;
        }
        /// <summary>
        /// get the ItemsHolder and generate any children
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.m_itemsHolderPanel = GetTemplateChild("PART_ItemsHolder") as Panel;
            UpdateSelectedItem();
        }
        #endregion

        #region MethodsProtected
        /// <summary>
        /// when the items change we remove any generated panel children and add any new ones as necessary
        /// </summary>
        /// <param name="e"></param>
        protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);

            if (this.m_itemsHolderPanel == null)
            {
                return;
            }

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Reset:
                    //ToDo: PageTabControl.OnItemsChanged event misbehaviour
                    //In a Wpf application the onitemschaged event raises before the loaded event but in a windows.forms application the loaded event
                    //raises before the onitemschaged event. Therefore this condition was implemented.
                    if (this.IsLoaded == false)
                    {
                        this.m_itemsHolderPanel.Children.Clear();
                    }
                    break;
                case NotifyCollectionChangedAction.Add:
                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems != null)
                    {
                        foreach (var item in e.OldItems)
                        {
                            ContentPresenter contentPresenter = FindChildContentPresenter(item);
                            if (contentPresenter != null)
                            {
                                this.m_itemsHolderPanel.Children.Remove(contentPresenter);
                            }
                        }
                    }

                    // don't do anything with new items because we don't want to
                    // create visuals that aren't being shown

                    UpdateSelectedItem();
                    break;

                case NotifyCollectionChangedAction.Replace:
                    throw new NotImplementedException("Replace not implemented yet");
            }
        }

        /// <summary>
        /// update the visible child in the ItemsHolder
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectionChanged(e);
            UpdateSelectedItem();
        }

        /// <summary>
        /// copied from TabControl; wish it were protected in that class instead of private
        /// </summary>
        /// <returns></returns>
        protected TabItem GetSelectedTabItem()
        {
            object selectedItem = base.SelectedItem;
            if (selectedItem == null)
            {
                return null;
            }
            TabItem item = selectedItem as TabItem;
            if (item == null)
            {
                item = base.ItemContainerGenerator.ContainerFromIndex(base.SelectedIndex) as TabItem;
            }
            return item;
        }
        #endregion

        #region MethodsPrivate

        /// <summary>
        /// in some scenarios we need to update when loaded in case the
        /// ApplyTemplate happens before the databind.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            UpdateSelectedItem();
        }

        /// <summary>
        /// if containers are done, generate the selected item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemContainerGenerator_StatusChanged(object sender, EventArgs e)
        {
            if (this.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
            {
                this.ItemContainerGenerator.StatusChanged -= ItemContainerGenerator_StatusChanged;
                UpdateSelectedItem();
            }
        }

        /// <summary>
        /// generate a ContentPresenter for the selected item
        /// </summary>
        private void UpdateSelectedItem()
        {
            if (this.m_itemsHolderPanel == null)
            {
                return;
            }

            // generate a ContentPresenter if necessary
            TabItem item = GetSelectedTabItem();
            if (item != null)
            {
                CreateChildContentPresenter(item);
            }

            // show the right child
            foreach (ContentPresenter child in this.m_itemsHolderPanel.Children)
            {
                child.Visibility = ((child.Tag as TabItem).IsSelected) ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        /// <summary>
        /// create the child ContentPresenter for the given item (could be data or a TabItem)
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private ContentPresenter CreateChildContentPresenter(object item)
        {
            if (item == null)
            {
                return null;
            }

            ContentPresenter contentPresenter = FindChildContentPresenter(item);
            if (contentPresenter != null)
            {
                return contentPresenter;
            }

            // the actual child to be added.  contentPresenter.Tag is a reference to the TabItem
            contentPresenter = new ContentPresenter();
            contentPresenter.Content = (item is TabItem) ? (item as TabItem).Content : item;
            contentPresenter.ContentTemplate = this.SelectedContentTemplate;
            contentPresenter.ContentTemplateSelector = this.SelectedContentTemplateSelector;
            contentPresenter.ContentStringFormat = this.SelectedContentStringFormat;
            contentPresenter.Visibility = Visibility.Collapsed;
            contentPresenter.Tag = (item is TabItem) ? item : (this.ItemContainerGenerator.ContainerFromItem(item));
            this.m_itemsHolderPanel.Children.Add(contentPresenter);
            return contentPresenter;
        }

        /// <summary>
        /// Find the CP for the given object.  data could be a TabItem or a piece of data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private ContentPresenter FindChildContentPresenter(object data)
        {
            if (data == null)
            {
                return null;
            }

            TabItem tabItem = data as TabItem;
            if (tabItem != null)
            {
                data = tabItem.Content;
            }

            if (this.m_itemsHolderPanel == null)
            {
                return null;
            }

            foreach (ContentPresenter contentPresenter in this.m_itemsHolderPanel.Children)
            {
                if (contentPresenter.Content == data)
                {
                    return contentPresenter;
                }
            }

            return null;
        }
        static PageTabControl()
        {
            FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(PageTabControl), new FrameworkPropertyMetadata(typeof(PageTabControl)));
        }
        #endregion
    }
}
