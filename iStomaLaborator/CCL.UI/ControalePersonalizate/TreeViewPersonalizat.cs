using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace CCL.UI
{
    public class TreeViewPersonalizat : TreeView
    {
        public TreeViewPersonalizat()
        {
            SeteazaDoubleBuffer();
        }

        public TreeViewPersonalizat(IContainer container)
            : this()
        {
            container.Add(this);
        }

        private void SeteazaDoubleBuffer()
        {
            // this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        public List<TreeNode> GetListaNoduriBifate()
        {
            List<TreeNode> listaRetur = new List<TreeNode>();

            GetListaNoduriBifate(this.TopNode, listaRetur);

            return listaRetur;
        }

        public void GetListaNoduriBifate(TreeNode pNod, List<TreeNode> listaRetur)
        {
            if (pNod == null)
            {
            }
            else
            {
                if (pNod.Checked)
                    listaRetur.Add(pNod);

                if (pNod.Nodes.Count > 0)
                {
                    foreach (TreeNode item in pNod.Nodes)
                    {
                        GetListaNoduriBifate(item, listaRetur);
                    }
                }
            }
        }

        #region Metode comune de creare noduri

        /// <summary>
        /// Cream un nod de creare
        /// Acesta are fontul Albastru
        /// </summary>
        /// <param name="pTagNod">Obiectul pe care il vom stoca in Tag (null sau enumerare)</param>
        /// <param name="pText">Textul nodului</param>
        /// <param name="pIndexImagine">Indexul imaginii (in cazul in care se foloseste ImageList)</param>
        /// <returns></returns>
        public TreeNode CreazaNodAdaugare(object pTagNod, string pText, int pIndexImagine, Color pCuloareText)
        {
            TreeNode xNod = new TreeNode();
            xNod.Tag = pTagNod;
            xNod.Text = pText;
            xNod.ForeColor = pCuloareText;
            xNod.SelectedImageIndex = pIndexImagine;
            xNod.ImageIndex = pIndexImagine;
            return xNod;
        }

        public TreeNode CreazaNodText(string pText, int pIndexImagine)
        {
            TreeNode xNod = new TreeNode();
            xNod.Text = pText;
            xNod.SelectedImageIndex = pIndexImagine;
            xNod.ImageIndex = pIndexImagine;
            return xNod;
        }

        /// <summary>
        /// Cream un nod de creare
        /// Acesta are fontul Albastru
        /// </summary>
        /// <param name="pTagNod">Obiectul pe care il vom stoca in Tag (null sau enumerare)</param>
        /// <param name="pText">Textul nodului</param>
        /// <param name="pIndexImagine">Indexul imaginii (in cazul in care se foloseste ImageList)</param>
        /// <returns></returns>
        public TreeNode CreazaNodObiect(object pTagNod, int pIndexImagine)
        {
            TreeNode xNod = new TreeNode();
            xNod.Tag = pTagNod;
            xNod.Text = pTagNod.ToString();
            xNod.SelectedImageIndex = pIndexImagine;
            xNod.ImageIndex = pIndexImagine;
            return xNod;
        }

        /// <summary>
        /// Incercam sa selectam obiectul care are id-ul trimis in parametru
        /// </summary>
        /// <param name="pListaNoduri">Lista de noduri in care se face cautarea</param>
        /// <param name="pTipObiect">Tipul Obiectului care se afla in Tag-ul in care facem cautarea</param>
        /// <param name="pIdObiect">Id-ul obiectului care trebuie selectat. 
        /// Metoda Tostring trebuie sa fie definita pentru acest tip de obiect</param>
        /// <returns></returns>
        public bool SelecteazaNod(TreeNodeCollection pListaNoduri, Type pTipObiect, long pIdObiect)
        {
            bool NodGasit = false;
            foreach (TreeNode xNode in pListaNoduri)
            {
                if (xNode.Tag.GetType().Equals(pTipObiect))
                {
                    if (xNode.Tag.Equals(pIdObiect))
                    {
                        this.SelectedNode = xNode;
                        xNode.EnsureVisible();
                        xNode.Expand();
                        NodGasit = true;
                        break;
                    }
                    else
                    {
                        if (xNode.Nodes.Count > 0)
                        {
                            NodGasit = SelecteazaNod(xNode.Nodes, pTipObiect, pIdObiect);
                            if (NodGasit)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            return NodGasit;
        }

        /// <summary>
        /// Eliminam nodurile ce au in Tag un anumit tip de obiect
        /// De exemplu enumerare pentru nodurile de creare
        /// </summary>
        /// <param name="pListaNoduri"></param>
        /// <param name="pTipObiect"></param>
        public void EliminaNoduriDeTip(Type pTipObiect)
        {
            List<TreeNode> lstNoduri = new List<TreeNode>();
            EliminaNoduriRecursiv(this.Nodes, pTipObiect, ref lstNoduri);
            foreach (TreeNode xNod in lstNoduri)
            {
                xNod.Remove();
            }
        }

        /// <summary>
        /// Eliminam nodurile recursiv
        /// Nodure ce trebuiesc sterse sunt de fapt adaugate intr-o lista si eliminate dupa ce aceasta lista este completa
        /// </summary>
        /// <param name="pListaNoduri"></param>
        /// <param name="pTipObiect"></param>
        /// <param name="lstNoduri"></param>
        private void EliminaNoduriRecursiv(TreeNodeCollection pListaNoduri, Type pTipObiect, ref List<TreeNode> lstNoduri)
        {
            foreach (TreeNode xNod in pListaNoduri)
            {
                if (xNod.Tag.GetType().Equals(pTipObiect))
                {
                    lstNoduri.Add(xNod);
                }
                else
                {
                    if (xNod.Nodes.Count > 0)
                    {
                        EliminaNoduriRecursiv(xNod.Nodes, pTipObiect, ref lstNoduri);
                    }
                }
            }
        }

        #endregion

    }
}
