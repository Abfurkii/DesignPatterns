using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            ScoringAlgorithm scoringAlgorithm;

            Console.WriteLine("Man");
            scoringAlgorithm = new ManScoringAlgorithm();
            var resultMan= scoringAlgorithm.GenerateScore(10, new TimeSpan(0, 2, 30));
            Console.WriteLine(resultMan);

            Console.WriteLine("Woman");
            scoringAlgorithm = new WomanScoringAlgorithm();
            var resultWoman = scoringAlgorithm.GenerateScore(10, new TimeSpan(0, 2, 30));
            Console.WriteLine(resultWoman);

            Console.WriteLine("Childeren");
            scoringAlgorithm = new ChilderenScoringAlgorithm();
            var resultChilderen = scoringAlgorithm.GenerateScore(10, new TimeSpan(0, 2, 30));
            Console.WriteLine(resultChilderen);


            Console.ReadLine();
        }
    }
    public abstract class ScoringAlgorithm
    {
        public int GenerateScore(int hits,TimeSpan time)
        {
            int score = CalculateBaseScore(hits);
            int reducation = CalculateReducation(time);
            return CalculateOverallScore(score,reducation);
        }

        public abstract int CalculateOverallScore(int score, int reducation);
        public abstract int CalculateReducation(TimeSpan time);
        public abstract int CalculateBaseScore(int hits);
    }
    public class ManScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 10;
        }

        public override int CalculateOverallScore(int score, int reducation)
        {
            return score - reducation;
        }

        public override int CalculateReducation(TimeSpan time)
        {
            return (int)time.TotalSeconds / 5;
        }
    }
    public class WomanScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 10;
        }

        public override int CalculateOverallScore(int score, int reducation)
        {
            return score - reducation;
        }

        public override int CalculateReducation(TimeSpan time)
        {
            return (int)time.TotalSeconds / 3;
        }
    }
    public class ChilderenScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 10;
        }

        public override int CalculateOverallScore(int score, int reducation)
        {
            return score - reducation;
        }

        public override int CalculateReducation(TimeSpan time)
        {
            return (int)time.TotalSeconds/2;
        }
    }
}
