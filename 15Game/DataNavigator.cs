using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _15Game
{
    public partial class DataNavigator : Form
    {
        BindingSource bindingSource = new BindingSource();

        public DataNavigator()
        {
            InitializeComponent();

            DataObjectCollection collection = new DataObjectCollection();

            bindingSource.DataSource = collection;
            bindingSource.DataMember = "Collection";

            this.bindingNavigator1.BindingSource = bindingSource;
            this.textBox1.DataBindings.Add("Text", bindingSource, "Name");
        }
    }
    public class DataObject
    {
        public string Name { get; set; }
        public DataObject()
        {

        }
        public DataObject(string n)
        {
            Name = n;
        }
    }
    public class DataObjectCollection
    {
        List<DataObject> collection = new List<DataObject>();
        public DataObjectCollection()
        {
            collection.Add(new DataObject("AAAAAAAA"));
            collection.Add(new DataObject("BBBBBBBB"));
            collection.Add(new DataObject("CCCCCCCC"));
            collection.Add(new DataObject("DDDDDDDD"));
        }
        public List<DataObject> Collection
        {
            get { return collection; }
        }
    }
}
