using System;
using System.Collections.Generic;

namespace CCL.UI.Caramizi.HTML
{

    // Enum used to insert a list
    public enum HtmlListType
    {
        Ordered,
        Unordered

    } //HtmlListType


    // Enum used to insert a heading
    public enum HtmlHeadingType
    {
        H1 = 1,
        H2 = 2,
        H3 = 3,
        H4 = 4,
        H5 = 5

    } //HtmlHeadingType


    // Enum used to define the navigate action on a user clicking a href
    public enum NavigateActionOption
    {
        Default,
        NewWindow,
        SameWindow

    } //NavigateActionOption


    // Enum used to define the image align property
    public enum ImageAlignOption
    {
        AbsBottom,
        AbsMiddle,
        Baseline,
        Bottom,
        Left,
        Middle,
        Right,
        TextTop,
        Top

    } //ImageAlignOption


    #region HorizontalAlignOption + StructHorizontalAlignOption

    public enum HorizontalAlignOption
    {
        Nedefinit = 0,
        /// <summary>
        /// Implicit
        /// </summary>
        Default = 1,
        /// <summary>
        /// Stanga
        /// </summary>
        Left = 2,
        /// <summary>
        /// Centru
        /// </summary>
        Center = 3,
        /// <summary>
        /// Dreapta
        /// </summary>
        Right = 4
    }

    public struct StructHorizontalAlignOption
    {
        #region Declaratii generale

        public HorizontalAlignOption Id { get; set; }
        public string Nume { get; set; }

        public static StructHorizontalAlignOption Empty { get { return GetStructByEnum(HorizontalAlignOption.Nedefinit); } }

        #endregion //Declaratii generale

        #region Constructori

        public StructHorizontalAlignOption(HorizontalAlignOption pId, string pNume)
            : this()
        {
            this.Id = pId;
            this.Nume = pNume;
        }

        #endregion //Constructori

        #region Metode suprascise

        public override string ToString()
        {
            return this.Nume;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else
            {
                if (obj is HorizontalAlignOption)
                    return this.Id.Equals((HorizontalAlignOption)obj);
                else
                {
                    if (obj is StructHorizontalAlignOption)
                        return this.Id.Equals(((StructHorizontalAlignOption)obj).Id);
                    else
                    {
                        if (obj is int)
                            return Convert.ToInt32(this.Id).Equals(Convert.ToInt32(obj));
                        else
                        {
                            if (obj is long)
                                return Convert.ToInt64(this.Id).Equals(Convert.ToInt64(obj));
                        }
                    }
                }
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion //Metode suprascise

        #region Metode Publice

        public static List<StructHorizontalAlignOption> GetList()
        {
            List<StructHorizontalAlignOption> lstStruct = new List<StructHorizontalAlignOption>();
            lstStruct.Add(GetStructByEnum(HorizontalAlignOption.Default));
            lstStruct.Add(GetStructByEnum(HorizontalAlignOption.Left));
            lstStruct.Add(GetStructByEnum(HorizontalAlignOption.Center));
            lstStruct.Add(GetStructByEnum(HorizontalAlignOption.Right));
            return lstStruct;
        }

        public static HorizontalAlignOption GetEnumByString(string pNume)
        {
            HorizontalAlignOption lId = HorizontalAlignOption.Nedefinit;
            foreach (StructHorizontalAlignOption xStruct in GetList())
            {
                if (xStruct.Nume.Equals(pNume.Trim()))
                {
                    lId = xStruct.Id;
                    break;
                }
            }

            return lId;
        }

        public static string GetStringByEnum(HorizontalAlignOption pId)
        {
            return GetStructByEnum(pId).Nume;
        }

        public static StructHorizontalAlignOption GetStructByEnum(HorizontalAlignOption pId)
        {
            switch (pId)
            {
                case HorizontalAlignOption.Default:
                    return new StructHorizontalAlignOption(HorizontalAlignOption.Default, IHMUtile.getText(1200));
                case HorizontalAlignOption.Left:
                    return new StructHorizontalAlignOption(HorizontalAlignOption.Left, IHMUtile.getText(1203)); //"Stânga");
                case HorizontalAlignOption.Center:
                    return new StructHorizontalAlignOption(HorizontalAlignOption.Center, IHMUtile.getText(1204)); //"Centru");
                case HorizontalAlignOption.Right:
                    return new StructHorizontalAlignOption(HorizontalAlignOption.Right, IHMUtile.getText(1205)); //"Dreapta");
            }
            return new StructHorizontalAlignOption(HorizontalAlignOption.Nedefinit, "");
        }

        public bool Exista()
        {
            return this.Id != HorizontalAlignOption.Nedefinit;
        }
    }

        #endregion //Metode Publice

    #endregion //HorizontalAlignOption + StructHorizontalAlignOption

    #region VerticalAlignOption + StructVerticalAlignOption

    public enum VerticalAlignOption
    {
        Nedefinit = 0,
        /// <summary>
        /// Implicit
        /// </summary>
        Default = 1,
        /// <summary>
        /// Deasupra
        /// </summary>
        Top = 2,
        /// <summary>
        /// Dedesubt
        /// </summary>
        Bottom = 3
    }

    public struct StructVerticalAlignOption
    {
        #region Declaratii generale

        public VerticalAlignOption Id { get; set; }
        public string Nume { get; set; }

        public static StructVerticalAlignOption Empty { get { return GetStructByEnum(VerticalAlignOption.Nedefinit); } }

        #endregion //Declaratii generale

        #region Constructori

        public StructVerticalAlignOption(VerticalAlignOption pId, string pNume)
            : this()
        {
            this.Id = pId;
            this.Nume = pNume;
        }

        #endregion //Constructori

        #region Metode suprascise

        public override string ToString()
        {
            return this.Nume;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else
            {
                if (obj is VerticalAlignOption)
                    return this.Id.Equals((VerticalAlignOption)obj);
                else
                {
                    if (obj is StructVerticalAlignOption)
                        return this.Id.Equals(((StructVerticalAlignOption)obj).Id);
                    else
                    {
                        if (obj is int)
                            return Convert.ToInt32(this.Id).Equals(Convert.ToInt32(obj));
                        else
                        {
                            if (obj is long)
                                return Convert.ToInt64(this.Id).Equals(Convert.ToInt64(obj));
                        }
                    }
                }
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion //Metode suprascise

        #region Metode Publice

        public static List<StructVerticalAlignOption> GetList()
        {
            List<StructVerticalAlignOption> lstStruct = new List<StructVerticalAlignOption>();
            lstStruct.Add(GetStructByEnum(VerticalAlignOption.Default));
            lstStruct.Add(GetStructByEnum(VerticalAlignOption.Top));
            lstStruct.Add(GetStructByEnum(VerticalAlignOption.Bottom));
            return lstStruct;
        }

        public static VerticalAlignOption GetEnumByString(string pNume)
        {
            VerticalAlignOption lId = VerticalAlignOption.Nedefinit;
            foreach (StructVerticalAlignOption xStruct in GetList())
            {
                if (xStruct.Nume.Equals(pNume.Trim()))
                {
                    lId = xStruct.Id;
                    break;
                }
            }

            return lId;
        }

        public static string GetStringByEnum(VerticalAlignOption pId)
        {
            return GetStructByEnum(pId).Nume;
        }

        public static StructVerticalAlignOption GetStructByEnum(VerticalAlignOption pId)
        {
            switch (pId)
            {
                case VerticalAlignOption.Default:
                    return new StructVerticalAlignOption(VerticalAlignOption.Default, IHMUtile.getText(1200)); //"Implicit");
                case VerticalAlignOption.Top:
                    return new StructVerticalAlignOption(VerticalAlignOption.Top, IHMUtile.getText(1201)); //"Deasupra");
                case VerticalAlignOption.Bottom:
                    return new StructVerticalAlignOption(VerticalAlignOption.Bottom, IHMUtile.getText(1202)); //"Dedesubt");
            }
            return new StructVerticalAlignOption(VerticalAlignOption.Nedefinit, "");
        }

        public bool Exista()
        {
            return this.Id != VerticalAlignOption.Nedefinit;
        }

        #endregion //Metode Publice

    }

    #endregion //VerticalAlignOption + StructVerticalAlignOption

    // Enum used to define the visibility of the scroll bars
    public enum DisplayScrollBarOption
    {
        Yes,
        No,
        Auto

    } //DisplayScrollBarOption


    // Enum used to define the unit of measure for a value
    public enum MeasurementOption
    {
        Pixel,
        Percent

    } //MeasurementOption

}