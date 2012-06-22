using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLibraryPro
{
    public class CardType
    {
        public string CardTypeCode { get; set; }
        public string TypeDesc { get; set; }
        public int BooksAllowed { get; set; }

        public CardType() { }
        public CardType(string new_code)
        {
            DLibraryPro.CardType.Populate(this, new_code);
        }
       
        public string SaveCardType()
        {
            return DLibraryPro.CardType.SaveCardType(this);   
        }

        public string UpdateCardType()
        {
            return DLibraryPro.CardType.UpdateCardType(this);
        }

        public string DeleteCardType()
        {
            return DLibraryPro.CardType.DeleteCardType(this);
        }

        public static DataTable GetCardTypes(string paramFilterValues)
        {
            return DLibraryPro.CardType.GetCardTypes(paramFilterValues);
        }
    }
}
