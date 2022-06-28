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
			var tReport = report.Distinct().			// 1) 겹치는거 제거(report = report.Distinct())
				Select(s => s.Split(' ')).				// 2) 요소별로 split한 결과를 배열{{0,1}, {0,1}, {0,1}, {0,1}}에 저장
				GroupBy(g => g[1]).						// 3) select 결과의 각요소의[1](= 신고 대상)을 키로 그룹화(string,string[])
				Where(w => w.Count() >= k).				// 4) 각 그룹의 요소 갯수가 k 이상인 경우만 뽑아냄
				SelectMany(sm => sm.Select(s => s[0])).	// 5) 뽑아낸 결과의 [0]요소(=신고자)만을 뽑아내 배열로 저장
				ToList();                               // 6) 그 결과를 리스트로 저장			

			// 즉,
			// 1) 신고목록에서 겹치는 부분을 삭제후
			// 2) 신고자와 신고대상으로 나누고
			// 3) 신고당한 사람s[1]을 기준으로 그룹화 하여( = Value에는 신고자s[0]들이 들어감)
			// 4) 그룹별 요소수(= 신고자수)가 >= k 인 경우만을 다시 선택하고
			// 5) 이 뽑아낸 결과에 대해서 2)의 결과의 [0]요소( = 신고자)와 겹치는 요소만을 뽑아냄(inner join)

			// 이러면
			// 1)	 '겹치는 신고가 제외된 결과'에서
			// 2)~3) '신고당한 사람별로 누가 신고했는지 목록을 그룹화'하고
			// 4)	 '신고한 사람이 k명 이상인 그룹'을 뽑아내서
			// 5)	 뽑은 그룹의 멤버(신고자)와 2)의 '신고자'목록의 겹치는 이름을 뽑는다.
			// 6)	 '신고한 사람들의 목록'이 출력됨 


			return id_list.ToDictionary(x => x, x => tReport.Count(c => x == c)).Values.ToArray();
			// id_list의 각 요소를
			// Dictionary의 키값으로,
			// tReport의 결과의 각 요소중 키값과 일치하는 것들의 갯수를 그 키값의 멤버로
			// Dictionary 생성 

			// 생성된 Dictionary의 멤버를 배열(int[])로 해서 출력
		}
	}
}
