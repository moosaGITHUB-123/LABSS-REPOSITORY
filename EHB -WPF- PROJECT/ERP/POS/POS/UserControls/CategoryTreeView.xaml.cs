using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows;


namespace TreeView_DataHierarchy
{

    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public void NodesFactory(DataTable InptDT, DataTable subDT, long level)
        {


            level = level + 1;


            var querryLevel =
            from itemsInputDT in InptDT.AsEnumerable()
            join itemSub in subDT.AsEnumerable() on itemsInputDT.Field<long>("GparentId") equals itemSub.Field<long>("Gid")
            where itemSub.Field<long>("level") == level - 1

            select new { Gid = itemsInputDT.Field<long>("Gid"), Gname = itemsInputDT.Field<string>("Gname"), GparentId = itemsInputDT.Field<long>("GparentId"), level = level };


            foreach (var x in querryLevel)
            {

                DataRow rowSub = subDT.NewRow();
                rowSub["Gid"] = x.Gid;
                rowSub["Gname"] = x.Gname;
                rowSub["GparentId"] = x.GparentId;
                rowSub["level"] = x.level;
                subDT.Rows.Add(rowSub);

                nodesList.Add(new NodeViewModel { Id = x.Gid, Name = x.Gname, Expand = true, Children = new ObservableCollection<NodeViewModel>() });

                nodesList.Find(gNode => gNode.Id == x.GparentId).Children.Add(nodesList.Last());

            }

            if (querryLevel.Count() > 0)
            { NodesFactory(InptDT, subDT, level); }


        }


        public event PropertyChangedEventHandler PropertyChanged;
        List<NodeViewModel> nodesList = new List<NodeViewModel>();
        TreeViewModel MyTreeModel = new TreeViewModel();

        public MainWindow()
        {

            //generic list comprising  hierarchical data- source to fill TreeViewModel
            List<GIER_Hierarchy> GIER_Hierarchy_List = new List<GIER_Hierarchy>();

            GIER_Hierarchy_List.Add(new GIER_Hierarchy(1, "root", 0));
            GIER_Hierarchy_List.Add(new GIER_Hierarchy(2, "Production B", 7));
            GIER_Hierarchy_List.Add(new GIER_Hierarchy(12, "Document Control", 17));
            GIER_Hierarchy_List.Add(new GIER_Hierarchy(17, "Engineering", 7));
            GIER_Hierarchy_List.Add(new GIER_Hierarchy(16, "Executive", 1));
            GIER_Hierarchy_List.Add(new GIER_Hierarchy(14, "Facilities and Maintenance", 7));
            GIER_Hierarchy_List.Add(new GIER_Hierarchy(10, "Finance", 16));
            GIER_Hierarchy_List.Add(new GIER_Hierarchy(9, "Human Resources", 16));
            GIER_Hierarchy_List.Add(new GIER_Hierarchy(11, "Information Services", 4));
            GIER_Hierarchy_List.Add(new GIER_Hierarchy(4, "Marketing", 16));
            GIER_Hierarchy_List.Add(new GIER_Hierarchy(7, "Production", 16));
            GIER_Hierarchy_List.Add(new GIER_Hierarchy(8, "Production Control", 7));
            GIER_Hierarchy_List.Add(new GIER_Hierarchy(5, "Purchasing", 18));
            GIER_Hierarchy_List.Add(new GIER_Hierarchy(13, "Quality Assurance", 7));
            GIER_Hierarchy_List.Add(new GIER_Hierarchy(6, "Research and Development", 16));
            GIER_Hierarchy_List.Add(new GIER_Hierarchy(3, "Sales", 16));
            GIER_Hierarchy_List.Add(new GIER_Hierarchy(15, "Shipping and Receiving", 18));
            GIER_Hierarchy_List.Add(new GIER_Hierarchy(19, "Tool Design", 2));
            GIER_Hierarchy_List.Add(new GIER_Hierarchy(18, "Logistic", 16));
            GIER_Hierarchy_List.Add(new GIER_Hierarchy(20, "Logistic A", 18));
            GIER_Hierarchy_List.Add(new GIER_Hierarchy(21, "Logistic A1", 20));
            GIER_Hierarchy_List.Add(new GIER_Hierarchy(22, "Logistic A1", 21));
            GIER_Hierarchy_List.Add(new GIER_Hierarchy(23, "Logistic A1", 22));
            GIER_Hierarchy_List.Add(new GIER_Hierarchy(24, "Logistic A1", 23));
            GIER_Hierarchy_List.Add(new GIER_Hierarchy(25, "Logistic A1", 24));


            if (GIER_Hierarchy_List.Count > 0)
            {

                //datatable to load data from GIER_Hierarchy_List
                DataTable InputDT = new DataTable();
                InputDT.Columns.Add("Gid", typeof(long));
                InputDT.Columns.Add("Gname", typeof(string));
                InputDT.Columns.Add("GparentId", typeof(long));

                //loading the data from  to datable
                foreach (var x in GIER_Hierarchy_List)
                {
                    DataRow rowInput = InputDT.NewRow();
                    rowInput["Gid"] = x.Gid;
                    rowInput["Gname"] = x.Gname;
                    rowInput["GparentId"] = x.GparentId;
                    InputDT.Rows.Add(rowInput);
                }

                //querring the datable to find the row with root as first level of hierachy
                var queryRoot =
                     from itemsInputDT in InputDT.AsEnumerable()
                     where itemsInputDT.Field<long>("GparentId") == 0
                     select new { Gid = itemsInputDT.Field<long>("Gid"), Gname = itemsInputDT.Field<string>("Gname"), GparentId = itemsInputDT.Field<long>("GparentId"), level = 1 };

                //creating auxiliary datatable for iterationaly querying in the subsequent levels of hierarchy
                DataTable sub = new DataTable();
                sub.Columns.Add("Gid", typeof(long));
                sub.Columns.Add("Gname", typeof(string));
                sub.Columns.Add("GparentId", typeof(long));
                sub.Columns.Add("level", typeof(long));

                //looping through the result of the querry to load the result of the query to auxiliary datable and adding nodes to list of nodes 

                foreach (var x in queryRoot)
                {
                    DataRow rowSub = sub.NewRow();
                    rowSub["Gid"] = x.Gid;
                    rowSub["Gname"] = x.Gname;
                    rowSub["GparentId"] = x.GparentId;
                    rowSub["level"] = 0;
                    sub.Rows.Add(rowSub);

                    //creating NodeViewModel and adding to the list of NodeViewModel object list

                    nodesList.Add(new NodeViewModel
                    {
                        Id = x.Gid,
                        Name = x.Gname,
                        Expand = true,
                        Children =

                            new ObservableCollection<NodeViewModel>()
                    });

                }

                //adding Collection of NodeViewModel object with the root to TreeModel

                MyTreeModel.Items = new ObservableCollection<NodeViewModel> { nodesList.Last() };

                long level = 0;


                NodesFactory(InputDT, sub, level);


            }
            else { MessageBox.Show("List of Direcitory is empty"); }

            InitializeComponent();

            // binding TreeView component with TreeModel
          //  GIER_catalogHierarchy.ItemsSource = MyTreeModel.Items;
        }

    }



    public class GIER_Hierarchy
    {
        public long Gid { get; set; }
        public string Gname { get; set; }
        public long GparentId { get; set; }


        public GIER_Hierarchy(long xGid, string xGname, long xGparentId)
        {
            this.Gid = xGid;
            this.Gname = xGname;
            this.GparentId = xGparentId;
        }

    }



    public class TreeViewModel
    {
        public ObservableCollection<NodeViewModel> Items { get; set; }

    }

    public class NodeViewModel : INotifyPropertyChanged
    {


        public long Id { get; set; }
        public string _Name;
        public bool _Expand;
        public string Name
        {

            get { return _Name; }

            set
            {

                if (_Name != value)
                {
                    _Name = value;
                    NotifyPropertyChanged("Name");
                }

            }
        }


        public bool Expand
        {
            get { return _Expand; }
            set
            {
                if (_Expand != value)
                {
                    _Expand = value;
                    NotifyPropertyChanged("Expand");
                }
            }
        }


        public ObservableCollection<NodeViewModel> Children { get; set; }


        #region INotifyPropertyChanged Members

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

    }


}
