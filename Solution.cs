/*
Disk Space Analysis


A company is performing an analysis on the computers at its main office. The computers are spaced along a single row. The analysis is performed in the following way:

1. Choose a contiguous segment of a certain number of computers starting from the beginning of the row.

2. Analyze the available hard disk space on each of the computers.

3. Determine the minimum available disk space within this segment.


After performing these steps for the first segment it is then repeated for the next segment continuing this procedure until the end of the row(i.e. segment size is 4, computers

1 to 4 would be analyzed, then 2 to 5, etc.). Given this analysis procedure, find the maximum available disk space among all the minima that are found during the analysis.


Example:


n = 3, number of computers

space = [8,2,4]

x=2, length of the analysis segments

In this array of computers, the subarrays of size 2 are [8,2] and [2,4]. 
Thus initial analysis return 2 and 2 because those are the minima for the segments. Finally the maximum of these values is 2. Therefore answer is 2.



complete the below function

class MyTest{
public static int FindMax(int x, List<Integer> space){

// Complete this function 


}

public static void main(String [] gg){


		int x = scan.nextInt(); // say x = 2
		int n = scan.nextInt(); // say n = 3
		List<Integer> space = new ArrayList<Integer>();
		for(int i=0;i<n;i++){
			int val = scan.nextInt();
			space.add(val);
		}
		
		sout("Max is " + FindMax(x,space));
}

}
 


*/
public int FindMax(int[] space, int x)
{
    var chunkNum = 1;
    var s = new Stack<int>();
    s.Push(0);

    for (int i = 1; i < space.Length; i++)
    {
        // first chunk
        if (i < x)
        {
            if (space[i] < space[s.Peek()])
            {
                s.Pop();
                s.Push(i);
            }
        }
        // other chunks
        else
        {
            // if found minimum is member of current chunk we just need to compare current number with it
            var peek = s.Peek();
            if (peek >= chunkNum)
            {
                s.Push(space[i] < space[peek] ? i: peek);
            }
            // we have to loop through current chunk to find minimum number
            else
            {                
                s.Push(i);
                
                var j = chunkNum;
                var count = 0;
                while (count++ < x)
                {
                    if (space[j] < space[s.Peek()])
                    {
                        s.Pop();
                        s.Push(j);
                    }
                    j++;
                }
            }
            // we are ready to go to next chunk
            chunkNum++;
        }
    }
    
    return s.Select(c => space[c]).Max(); // what does this statement do. I am from Java was not able to figure it out.
}
