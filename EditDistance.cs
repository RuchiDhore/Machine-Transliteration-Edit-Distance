using System;

class EditDistance {
	// x-ref_name and y-cand_name
	int edit_distance(string x,string y) {
        int rr=20;int cc=20;
        int[,]d=new int[rr,cc];
        int m1=0,n1=0,i1=0,j1=0,d1=0,d2=0,d3=0;

        m1=x.Length;
        n1=y.Length;
        x=x+"\0";
        y=y+"\0";
        for(i1=1;i1<=m1;i1++)
        {
        if(i1< 2)
        d[i1,0]=d[i1-1,0];
        d[i1,0]=d[i1-1,0]+D(x[i1-1],x[i1]);
        }

        for(j1=1;j1<=n1;j1++)
        {
        if(j1< 2)
        d[0,j1]=d[0,j1-1];
        d[0,j1]=d[0,j1-1]+D(y[j1-1],y[j1]);
        }

        for(i1=1;i1<=m1;i1++) {
			for(j1=1;j1<=n1;j1++) {
				d1=d[i1-1,j1]+D(x[i1-1],x[i1]);  // a deleti1on
				d2=d[i1,j1-1]+D(y[j1-1],y[j1]);  // an insertion
				d3=d[i1-1,j1-1]+S(x[i1],y[j1]); // a substitution
				d[i1,j1]=findmin(d1,d2,d3);
			}
        }
		
        int dis=0;
        float edit_score=0;
        Double precision_single=0;
        Double precision_Avg=0;

        Double recall_single=0;
        Double recall_Avg=0;

        Double F_Score_single=0;
        Double F_Score_Avg=0;

        dis=d[m1,n1];
        edit_score=1-(dis/(m1+n1));
        LCS=0.5*((m1+n1)-dis);

        precision_single=(LCS/m1);
        precision=precision+precision_single;
        precision_Avg=precision/gc;

        recall_single=(LCS/n1);
        recall=recall+recall_single;
        recall_Avg=recall/gc;

        F_Score_single=2*((precision_single*recall_single)/(precision_single+recall_single));
        F_Score=F_Score+F_Score_single;
        F_Score_Avg=F_Score/gc;

        string CandidateName1=edit_score.ToString();
        string CandidateName2=precision_Avg.ToString();
        string CandidateName3=recall_Avg.ToString();
        string CandidateName4=F_Score_Avg.ToString();
        return 0;
    }

    int findmin(int d1,int d2,int d3) {
		if(d1<d2 &&d1<d3) return d1;
		else if(d1<d3) return d2;
		else if(d2<d3) return d2;
		else return d3;
    }
}