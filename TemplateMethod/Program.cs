using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            ScoringAlgorithtm algorithtm;
            Console.WriteLine("Mans");
            algorithtm = new ManScoringAlgoritmathm();
            Console.Write(algorithtm.GenaretaScoring(10,  new TimeSpan(0, 2, 34)));

            Console.WriteLine( "Woman");
            algorithtm = new womanScoringAlgoritmahtm();
            Console.WriteLine(algorithtm.GenaretaScoring(10, new TimeSpan(0, 2, 34)));

            Console.WriteLine( "Childiren");
            algorithtm = new childirenScoringAlgoritmahtm();
            Console.WriteLine(algorithtm.GenaretaScoring(10, new TimeSpan(0, 2, 34)));

            Console.ReadLine();
        }
    }
    abstract class ScoringAlgorithtm
    {
        public int GenaretaScoring(int hits, TimeSpan time)
        {
            int score = CalculateBaseScore(hits);
            int redaction = CalculateRedaction(time);
            return CalculateOvarelScore(score, redaction);
        }

        public abstract int CalculateOvarelScore(int score, int redaction);
        public abstract int CalculateRedaction(TimeSpan time);
        public abstract int CalculateBaseScore(int hits);
    }
    class ManScoringAlgoritmathm : ScoringAlgorithtm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }

        public override int CalculateOvarelScore(int score, int redaction)
        {
            return score - redaction;
        }

        public override int CalculateRedaction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 5;
        }
    }
    class womanScoringAlgoritmahtm : ScoringAlgorithtm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }

        public override int CalculateOvarelScore(int score, int redaction)
        {
            return score - redaction;
        }

        public override int CalculateRedaction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 3;
        }
    }
    class childirenScoringAlgoritmahtm : ScoringAlgorithtm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 80;
        }

        public override int CalculateOvarelScore(int score, int redaction)
        {
            return score -redaction;
        }

        public override int CalculateRedaction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 2;
        }
    }
}
