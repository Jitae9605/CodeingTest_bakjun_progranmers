using System;
using System.Collections.Generic;

public class K번째수
{
	public int[] solution(int[] array, int[,] commands)
	{
		int[] answer = new int[commands.GetLength(0)];

		List<int> list = new List<int>();
		for (int i = 0; i < commands.GetLength(0); i++)
		{
			list.Clear();
			int a = commands[i, 0] - 1;
			int b = commands[i, 1];
			int c = commands[i, 2] - 1;
			for (int j = a; j < b; j++)
			{
				list.Add(array[j]);
			}

			list.Sort();
			answer[i] = list[c];
		}

		return answer;
	}
}