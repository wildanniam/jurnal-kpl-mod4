public class KodeBuah
{
    public enum Buah
    {
        Apel, Aprikot, Alpukat, Pisang, Paprika, Blackberry, Ceri,
        Kelapa, Jagung, Kurma, Durian, Anggur, Melon, Semangka
    }

    public static string getKodeBuah(Buah buah)
    {
        string[] kodeBuah = { "A00", "B00", "C00", "D00", "E00", "F00", "H00", "I00", "J00", "K00", "L00", "M00", "N00", "O00" };
        return kodeBuah[(int)buah];
    }

}



























































