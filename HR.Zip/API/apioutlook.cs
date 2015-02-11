using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;

namespace HR.Zip.API
{

    class apioutlook
    {
        public Outlook.Application app;
        Outlook.MailItem mail;
        Outlook.NameSpace ns;

        public apioutlook()
        {
            app = new Outlook.Application();
            ns = app.GetNamespace("mapi");
        }
        public bool sendmail(string mailto, string mailcc, string strSubject, string strbody, string[] tmpAttachFilePath, string msg)
        {
            try
            {
                mail = (Outlook.MailItem)app.CreateItem(Outlook.OlItemType.olMailItem);
                //ns.Logon("ling.xie", "", false, true);
                mail.To = mailto;
                mail.CC = mailcc;

                mail.Subject = strSubject;

                mail.HTMLBody = strbody;

                foreach (var item in tmpAttachFilePath)
                {
                    mail.Attachments.Add(item, Outlook.OlAttachmentType.olByValue, Type.Missing, Type.Missing);
                }

                mail.Send();
                return true;
                //ns.Logoff();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public void cbinitAddLists(ComboBox cb)
        {
            Outlook.AddressLists addrLists =
               app.Session.AddressLists;
            foreach (Outlook.AddressList addrList in addrLists)
            {
                try
                {
                    if (addrList.AddressEntries.Count > 0)
                    {
                        cb.Items.Add(addrList.Name);
                    }
                }
                catch (Exception)
                {

                    continue;
                }

            }
        }
        public void dgvaddEmailUsernameByExchange(object o)
        {
            var exchange = ns.GetGlobalAddressList();

            foreach (Outlook.AddressEntry item in exchange.AddressEntries)
            {
                Outlook.ExchangeUser exuser = item.GetExchangeUser();
                Program._exuser.Add(exuser);
            }
            Program._exuserThreadinitover = true;
        }
        public void dgvGetSMTPAddressForRecipients(DataGridView dgv)
        {
            const string PR_SMTP_ADDRESS =
                "http://schemas.microsoft.com/mapi/proptag/0x39FE001E";
            Outlook.Recipients recips = mail.Recipients;
            foreach (Outlook.Recipient recip in recips)
            {
                Outlook.PropertyAccessor pa = recip.PropertyAccessor;
                string smtpAddress =
                    pa.GetProperty(PR_SMTP_ADDRESS).ToString();

                DataGridViewRow dgvr = new DataGridViewRow();
                dgvr.CreateCells(dgv);
                dgvr.Cells[0].Value = recip.Name;
                dgvr.Cells[1].Value = smtpAddress;
                dgv.Rows.Add(dgvr);

                //Debug.WriteLine(recip.Name + " SMTP=" + smtpAddress);
            }
        }
        public void dgvAddEmailUsername(DataGridView dgv, string addname)
        {
            Outlook.AddressLists addrLists =
                  app.Session.AddressLists;

            var myFolder = ns.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts);

            foreach (Outlook.AddressList addrList in addrLists)
            {
                if (addrList.Name.Equals(addname))
                {
                    foreach (Outlook.AddressEntry item in addrList.AddressEntries)
                    {
                        if (item.AddressEntryUserType == Outlook.OlAddressEntryUserType.olExchangeUserAddressEntry)
                        {
                            Outlook.ExchangeUser exuser = item.GetExchangeUser();
                            DataGridViewRow dgvr = new DataGridViewRow();
                            dgvr.CreateCells(dgv);
                            dgvr.Cells[0].Value = exuser.Name;
                            dgvr.Cells[1].Value = exuser.PrimarySmtpAddress;
                            dgv.Rows.Add(dgvr);
                        }
                        else if (item.AddressEntryUserType == Outlook.OlAddressEntryUserType.olOutlookContactAddressEntry)
                        {
                            Outlook.ContactItem exuser = item.GetContact();
                            DataGridViewRow dgvr = new DataGridViewRow();
                            dgvr.CreateCells(dgv);
                            dgvr.Cells[0].Value = exuser.FullName;
                            dgvr.Cells[1].Value = exuser.Email1Address;
                            dgv.Rows.Add(dgvr);
                        }

                    }
                    break;
                }

            }

        }
        public void GetDistributionListMembers(string addlistname, DataGridView dgv)
        {
            Outlook.SelectNamesDialog snd =
                app.Session.GetSelectNamesDialog();
            Outlook.AddressLists addrLists =
                app.Session.AddressLists;
            foreach (Outlook.AddressList addrList in addrLists)
            {
                if (addrList.Name == addlistname)
                {
                    snd.InitialAddressList = addrList;
                    break;
                }
            }
            snd.NumberOfRecipientSelectors = Outlook.OlRecipientSelectors.olShowTo;
            snd.ToLabel = "D/L";
            snd.ShowOnlyInitialAddressList = true;
            snd.AllowMultipleSelection = false;
            snd.Display();
            if (snd.Recipients.Count > 0)
            {
                Outlook.AddressEntry addrEntry =
                    snd.Recipients[1].AddressEntry;
                if (addrEntry.AddressEntryUserType ==
                    Outlook.OlAddressEntryUserType.
                    olExchangeDistributionListAddressEntry)
                {
                    Outlook.ExchangeDistributionList exchDL =
                        addrEntry.GetExchangeDistributionList();
                    Outlook.AddressEntries addrEntries =
                        exchDL.GetExchangeDistributionListMembers();
                    if (addrEntries != null)
                        foreach (Outlook.AddressEntry exchDLMember
                            in addrEntries)
                        {
                            DataGridViewRow dgvr = new DataGridViewRow();
                            dgvr.CreateCells(dgv);
                            dgvr.Cells[0].Value = exchDLMember.Name;
                            dgvr.Cells[1].Value = exchDLMember.Address;
                            dgv.Rows.Add(dgvr);
                            // Debug.WriteLine(exchDLMember.Name);
                        }
                }
            }
        }
        public void GetCurrentUserMembership(DataGridView dgv)
        {
            Outlook.AddressEntry currentUser =
                app.Session.CurrentUser.AddressEntry;
            if (currentUser.Type == "EX")
            {
                Outlook.ExchangeUser exchUser =
                    currentUser.GetExchangeUser();
                if (exchUser != null)
                {
                    Outlook.AddressEntries addrEntries =
                        exchUser.GetMemberOfList();
                    if (addrEntries != null)
                    {
                        foreach (Outlook.AddressEntry addrEntry
                            in addrEntries)
                        {
                            DataGridViewRow dgvr = new DataGridViewRow();
                            dgvr.CreateCells(dgv);
                            dgvr.Cells[0].Value = addrEntry.Name;
                            dgvr.Cells[1].Value = addrEntry.Address;
                            dgv.Rows.Add(dgvr);
                        }
                    }
                }
            }
        }

        #region set filepath
        public string getfilepath()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            return fbd.SelectedPath;
        }
        #endregion
    }
}
