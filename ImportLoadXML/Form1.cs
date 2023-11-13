using ImportLoadXML.XMLParser;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ImportLoadXML
{
    public partial class Form1 : Form
    {
        private const string FILE_XML = "Cards_20211005080948.xml";
        private List<CardXMLData> cards;
        private TestDBEntities context;
        public Form1()
        {
            InitializeComponent();
            context = new TestDBEntities();
        }

        private void toolStripLoadDataFromXMLFile_Click(object sender, EventArgs e)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Cards));
                using (FileStream fs = new FileStream(FILE_XML, FileMode.Open))
                {
                    cards = ((Cards)serializer.Deserialize(fs)).Card;
                }
                cards.ForEach(item => context.Card.Add(new Card()
                {
                    CARDCODE = item.CARDCODE,
                    STARTDATE = item.IsNULLSTARTDATE(),
                    FINISHDATE = item.IsNULLFINISHDATE(),
                    LASTNAME = item.LASTNAME,
                    FIRSTNAME = item.FIRSTNAME,
                    SURNAME = item.SURNAME,
                    FULLNAME = item.FULLNAME,
                    GENDERID = byte.Parse(item.GENDERID),
                    BIRTHDAY = item.IsNullOrEmptyBIRTHDAY(),
                    PHONEHOME = item.PHONEHOME,
                    EMAIL = item.EMAIL,
                    PHONEMOBIL = item.PHONEMOBIL,
                    CITY = item.CITY,
                    STREET = item.STREET,
                    HOUSE = item.IsNullOrEmptyHOUSE(),
                    APARTMENT = item.IsNullOrEmptyAPARTMENT(),
                    ALTADDRESS = item.ALTADDRESS,
                    CARDTYPE = item.CARDTYPE,
                    OWNERGUID = Guid.Parse(item.OWNERGUID),
                    CARDPER = byte.Parse(item.CARDPER),
                    TURNOVER = decimal.Parse(item.TURNOVER.Replace(".", ","))
                }));
                context.SaveChanges();
                cardBindingSource.DataSource = context.Card.ToList();

            }
            catch (FileNotFoundException ex1)
            {
                MessageBox.Show("Файл не найден");
            }
            catch (DbEntityValidationException ex2)
            {
                foreach (DbEntityValidationResult validationError in ex2.EntityValidationErrors)
                {
                    MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());

                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        MessageBox.Show(err.ErrorMessage + "");
                    }
                }
            }
            catch (Exception ex3)
            {
                MessageBox.Show("Ошибка при обработке файла: " + ex3.Message);
            }
        }

        private void cardBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            context.SaveChanges();
            this.cardDataGridView.Refresh();
        }
    }
}
