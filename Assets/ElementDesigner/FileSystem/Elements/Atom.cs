using System;
using System.Collections.Generic;

public enum BondType { None = 0, Covalent = 1, Ionic = 2, Metallic = 3 }

[Serializable]
public class Atom : Element
{
    public Atom() : base(1)
    {
        Name = "NewAtom";
        ShortName = "NW";
        ParticleIds = new int[] { 1 };
        ElementType = ElementType.Atom;
    }

    ///<summary>The atomic number of this atom, based on Proton count</summary>
    public int Number = 1;

    public int[] ParticleIds = new int[0];
    public int[] IsotopeIds = new int[0];
    public int ParentId = -1;

    // TODO: Valence shells and electrons divided into shells
    // TODO: Valence shell composition to affect reactivity

    public BondType BondType = BondType.None;

    public int Conductivity = 0;
    public int Reactivity = 0;
    public int Toxicity = 0;
    public int MeltingPoint = 0;
    public int BoilingPoint = 0;
    public int Brittleness = 0;
    public int Malleability = 0;
    public int Ductility = 0;


}

