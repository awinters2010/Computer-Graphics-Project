using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphics
{
    class ShapeListItem
    {
        private int myID;
        private string myShapeDesc;

        public ShapeListItem(int iID, string sShapeDesc)
        {

            this.myID = iID;
            this.myShapeDesc = sShapeDesc;
        }

        public int ID
        {
            get
            {
                return myID;
            }
        }

        public string ShapeDesc
        {

            get
            {
                return myID.ToString() + " - " + myShapeDesc;
            }
        }
    }
}
