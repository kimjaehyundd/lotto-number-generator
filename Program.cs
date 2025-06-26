using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;

namespace LottoNumberGenerator
{
    /// <summary>
    /// 로또 번호 생성기 메인 클래스
    /// 1부터 45까지 숫자 중에서 중복 없이 6개의 번호를 생성합니다.
    /// </summary>
    class Program
    {
        private static readonly string HistoryFile = "lotto_history.json";
        
        static void Main(string[] args)
        {
            Console.WriteLine("🎰 로또 번호 생성기 v1.0.0 🎰");
            Console.WriteLine("=".PadRight(50, '='));
            Console.WriteLine("📅 빌드 날짜: " + DateTime.Now.ToString("yyyy-MM-dd"));
            Console.WriteLine("👤 개발자: 김재현");
            Console.WriteLine();
            
            var generator = new LottoGenerator();
            var history = LoadHistory();
            
            while (true)
            {
                ShowMenu();
                
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("❌ 올바른 숫자를 입력해주세요!\n");
                    continue;
                }
                
                switch (choice)
                {
                    case 1:
                        var singleSet = generator.GenerateSingleSet();
                        history.Add(singleSet);
                        SaveHistory(history);
                        break;
                    case 2:
                        var multipleSets = generator.GenerateMultipleSets();
                        history.AddRange(multipleSets);
                        SaveHistory(history);
                        break;
                    case 3:
                        ShowHistory(history);
                        break;
                    case 4:
                        ShowStatistics(history);
                        break;
                    case 5:
                        Console.WriteLine("👋 이용해주셔서 감사합니다! 행운을 빕니다!");
                        return;
                    default:
                        Console.WriteLine("❌ 1~5 중에서 선택해주세요!\n");
                        break;
                }
                
                Console.WriteLine("\n계속하려면 아무 키나 눌러주세요...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        
        static void ShowMenu()
        {
            Console.WriteLine("\n📋 메뉴를 선택해주세요:");
            Console.WriteLine("1. 로또 번호 1세트 생성");
            Console.WriteLine("2. 로또 번호 여러 세트 생성");
            Console.WriteLine("3. 생성 이력 보기");
            Console.WriteLine("4. 번호 통계 보기");
            Console.WriteLine("5. 종료");
            Console.Write("\n선택: ");
        }
        
        static void ShowHistory(List<LottoResult> history)
        {
            if (history.Count == 0)
            {
                Console.WriteLine("\n📝 아직 생성된 번호가 없습니다.");
                return;
            }
            
            Console.WriteLine($"\n📝 생성 이력 (총 {history.Count}세트):");
            Console.WriteLine("-".PadRight(50, '-'));
            
            var recent = history.TakeLast(10);
            foreach (var result in recent)
            {
                Console.WriteLine($"{result.GeneratedAt:yyyy-MM-dd HH:mm:ss} | {string.Join(" - ", result.Numbers)}");
            }
            
            if (history.Count > 10)
            {
                Console.WriteLine($"... 그 외 {history.Count - 10}개 세트");
            }
        }
        
        static void ShowStatistics(List<LottoResult> history)
        {
            if (history.Count == 0)
            {
                Console.WriteLine("\n📊 통계를 보기 위한 데이터가 부족합니다.");
                return;
            }
            
            Console.WriteLine($"\n📊 번호 통계 (총 {history.Count}세트 분석):");
            Console.WriteLine("-".PadRight(50, '-'));
            
            var numberFrequency = new Dictionary<int, int>();
            
            foreach (var result in history)
            {
                foreach (var number in result.Numbers)
                {
                    numberFrequency[number] = numberFrequency.GetValueOrDefault(number, 0) + 1;
                }
            }
            
            var topNumbers = numberFrequency
                .OrderByDescending(x => x.Value)
                .Take(10)
                .ToList();
            
            Console.WriteLine("🔥 가장 많이 나온 번호 TOP 10:");
            for (int i = 0; i < topNumbers.Count; i++)
            {
                var (number, count) = topNumbers[i];
                Console.WriteLine($"{i + 1,2}. 번호 {number,2}: {count,3}회");
            }
        }
        
        static List<LottoResult> LoadHistory()
        {
            try
            {
                if (File.Exists(HistoryFile))
                {
                    var json = File.ReadAllText(HistoryFile);
                    return JsonSerializer.Deserialize<List<LottoResult>>(json) ?? new List<LottoResult>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ 이력 파일 로드 중 오류: {ex.Message}");
            }
            
            return new List<LottoResult>();
        }
        
        static void SaveHistory(List<LottoResult> history)
        {
            try
            {
                var json = JsonSerializer.Serialize(history, new JsonSerializerOptions 
                { 
                    WriteIndented = true 
                });
                File.WriteAllText(HistoryFile, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ 이력 파일 저장 중 오류: {ex.Message}");
            }
        }
    }
    
    /// <summary>
    /// 로또 번호 생성 결과를 나타내는 클래스
    /// </summary>
    public class LottoResult
    {
        public List<int> Numbers { get; set; } = new();
        public DateTime GeneratedAt { get; set; } = DateTime.Now;
    }
    
    /// <summary>
    /// 로또 번호 생성 로직을 담당하는 클래스
    /// </summary>
    public class LottoGenerator
    {
        private readonly Random _random;
        private readonly string[] _luckyMessages = {
            "🍀 오늘은 당신의 행운의 날입니다!",
            "⭐ 이 번호로 대박나세요!",
            "🎈 행운이 함께하길 바랍니다!",
            "💎 당신의 꿈이 이루어지길!",
            "🌈 희망찬 미래가 기다리고 있어요!",
            "🎉 행운의 여신이 미소 짓고 있어요!",
            "✨ 오늘이 바로 그 날입니다!",
            "🎯 정확히 맞힐 것 같은 예감이 드네요!"
        };
        
        public LottoGenerator()
        {
            _random = new Random();
        }
        
        /// <summary>
        /// 단일 로또 번호 세트를 생성합니다.
        /// </summary>
        /// <returns>생성된 로또 번호 결과</returns>
        public LottoResult GenerateSingleSet()
        {
            Console.WriteLine("\n🎲 로또 번호를 생성중입니다...");
            
            var numbers = GenerateLottoNumbers();
            var result = new LottoResult { Numbers = numbers };
            
            Console.WriteLine("\n🎉 생성된 로또 번호:");
            Console.WriteLine($"   {string.Join(" - ", numbers)}");
            
            var luckyMessage = _luckyMessages[_random.Next(_luckyMessages.Length)];
            Console.WriteLine($"\n{luckyMessage}");
            
            return result;
        }
        
        /// <summary>
        /// 여러 개의 로또 번호 세트를 생성합니다.
        /// </summary>
        /// <returns>생성된 로또 번호 결과들</returns>
        public List<LottoResult> GenerateMultipleSets()
        {
            Console.Write("\n몇 세트를 생성하시겠습니까? (1-10): ");
            
            if (!int.TryParse(Console.ReadLine(), out int setCount) || setCount < 1 || setCount > 10)
            {
                Console.WriteLine("❌ 1~10 사이의 숫자를 입력해주세요!");
                return new List<LottoResult>();
            }
            
            var results = new List<LottoResult>();
            
            Console.WriteLine($"\n🎲 로또 번호 {setCount}세트를 생성중입니다...");
            Console.WriteLine("\n🎉 생성된 로또 번호들:");
            Console.WriteLine("-".PadRight(40, '-'));
            
            for (int i = 1; i <= setCount; i++)
            {
                var numbers = GenerateLottoNumbers();
                var result = new LottoResult { Numbers = numbers };
                results.Add(result);
                
                Console.WriteLine($"세트 {i,2}: {string.Join(" - ", numbers)}");
                
                // 각 세트 생성 사이에 잠깐 딜레이 (더 실감나게)
                if (i < setCount)
                {
                    System.Threading.Thread.Sleep(300);
                }
            }
            
            Console.WriteLine("-".PadRight(40, '-'));
            Console.WriteLine($"✨ 총 {setCount}세트 생성 완료! 행운을 빕니다! ✨");
            
            return results;
        }
        
        /// <summary>
        /// 1부터 45까지 숫자 중에서 중복 없이 6개를 선택합니다.
        /// </summary>
        /// <returns>정렬된 로또 번호 리스트</returns>
        private List<int> GenerateLottoNumbers()
        {
            var numbers = new HashSet<int>();
            
            // 1부터 45까지 숫자 중에서 중복 없이 6개 선택
            while (numbers.Count < 6)
            {
                int number = _random.Next(1, 46); // 1~45
                numbers.Add(number);
            }
            
            // 오름차순으로 정렬해서 반환
            return numbers.OrderBy(n => n).ToList();
        }
    }
}