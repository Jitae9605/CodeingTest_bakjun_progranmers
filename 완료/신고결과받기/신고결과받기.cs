using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programmers
{
	public class MainClass
	{

		public static int Main()
		{
			string[] id_list = new string[] { "muzi", "frodo", "apeach", "neo" };
			string[] report = new string[] { "muzi frodo", "apeach frodo", "frodo neo", "muzi neo",
									"apeach muzi", "muzi frodo", "apeach frodo", "frodo neo",
									"muzi neo", "apeach muzi" };
			int k = 2;

			for (int i = 0; i < id_list.Length; i++)
			{
				Console.WriteLine(Solution(id_list, report, k)[i]);
			}
		

			return 0;
		}

		public static int[] Solution(string[] id_list, string[] report, int k)
		{
			// 회원 / 신고자
			Dictionary<string, List<string>> reported = new Dictionary<string, List<string>>();
			foreach (string id in id_list)
			{
				reported.Add(id, new List<string>());
			}

			// 신고내용 나누기
			string[] Getdata = new string[2];

			// 신고 같은 내용 삭제
			string[] DistincRepot = report.Distinct().ToArray();

			// 결과
			int[] answer = new int[id_list.Length];

			// 회원별 신고당한거 누가 신고했는지 저장
			for(int i = 0; i < DistincRepot.Length; i++)
			{
				Getdata = DistincRepot[i].Split(' ');
				reported[Getdata[1]].Add(Getdata[0]);
			}

			foreach(var item in reported)
			{
				if(item.Value.Count >= k)
				{
					foreach(var value in item.Value)
					{
						for (int i = 0; i < id_list.Length; i++)
						{
							if (id_list[i] == value) { answer[i]++; }
						}
							
					}
					
					
				}
			}
		


			return answer;
		}
	}
}
