using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kudlackova_test_12._12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeComponent();
            vypisy = SqlRepository.GetVypis();
            RefreshGUI();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        List<Vypis> vypisy;
        SqlRepository sqlRepoitory = new SqlRepository();
    }
    private void RefreshGUI()
    {
        listView1.Items.Clear();
        foreach (Vypis vypis in vypisy)
        {
            ListViewItem listViewItem = new ListViewItem(new string[] { faktura.cislo.ToString(), faktura.datum.ToString("dd.MM.yyyy"), faktura.odberatel, faktura.nazev, faktura.pocet.ToString(), faktura.cena.ToString() });
            listView1.Items.Add(listViewItem);
        }
    }
}
