using System.Threading.Channels;

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
    public enum PosisiKarakterGameState { TENGKURAP, JONGKOK, BERDIRI, TERBANG };
    public enum Trigger { TOMBOLW, TOMBOLS, TOMBOLX };
    public class PosisiKarakterGame
    {
        public PosisiKarakterGameState currentState = PosisiKarakterGameState.BERDIRI;

        public class Transition
        {

            public PosisiKarakterGameState stateAwal;
            public PosisiKarakterGameState stateAkhir;
            public Trigger trigger;
            public Transition(PosisiKarakterGameState stateAwal, PosisiKarakterGameState stateAkhir, Trigger trigger)
            {
                this.stateAwal = stateAwal;
                this.stateAkhir = stateAkhir;
                this.trigger = trigger;
            }
        }

        Transition[] transisi =
        {
            new Transition(PosisiKarakterGameState.TENGKURAP, PosisiKarakterGameState.JONGKOK, Trigger.TOMBOLW),
            new Transition(PosisiKarakterGameState.JONGKOK, PosisiKarakterGameState.TENGKURAP, Trigger.TOMBOLS),
            new Transition(PosisiKarakterGameState.JONGKOK, PosisiKarakterGameState.BERDIRI, Trigger.TOMBOLW),
            new Transition(PosisiKarakterGameState.BERDIRI, PosisiKarakterGameState.JONGKOK, Trigger.TOMBOLS),
            new Transition(PosisiKarakterGameState.BERDIRI, PosisiKarakterGameState.TERBANG, Trigger.TOMBOLW),
            new Transition(PosisiKarakterGameState.TERBANG, PosisiKarakterGameState.BERDIRI, Trigger.TOMBOLS),
            new Transition(PosisiKarakterGameState.TERBANG, PosisiKarakterGameState.JONGKOK, Trigger.TOMBOLX),
        };

        public PosisiKarakterGameState GetNextState(PosisiKarakterGameState stateAwal, Trigger trigger)
        {
            PosisiKarakterGameState stateAkhir = stateAwal;

            for (int i = 0; i < transisi.Length; i++)
            {
                Transition perubahan = transisi[i];

                if (stateAwal == perubahan.stateAwal && trigger == perubahan.trigger)
                {
                    stateAkhir = perubahan.stateAkhir;
                }
            }

            return stateAkhir;
        }

        public void ActivateTrigger(Trigger trigger)
        {
            PosisiKarakterGameState stateAwal = currentState;
            currentState = GetNextState(currentState, trigger);
            if (stateAwal == PosisiKarakterGameState.TERBANG && currentState == PosisiKarakterGameState.JONGKOK)
            {
                Console.WriteLine("Posisi Landing");
            }

            if (stateAwal == PosisiKarakterGameState.BERDIRI && currentState == PosisiKarakterGameState.TERBANG)
            {
                Console.WriteLine("Posisi Take Off");
            }
        }
    }

    private static void Main(string[] args)
    {
        PosisiKarakterGame game = new PosisiKarakterGame();
        Console.WriteLine("State Awal Sedang Berdiri");
        game.ActivateTrigger(Trigger.TOMBOLW);
        game.ActivateTrigger(Trigger.TOMBOLX);
    }
}


























































/* https://lms.telkomuniversity.ac.id/pluginfile.php/4870624/question/questiontext/8819857/1/70378615/Tugas%20Jurnal%20Modul%204.pdf */


