# 排序

## 插入类排序
1. 直接插入排序
	* 基本思想：
		* 将一个记录插入到已排好的有序表中，从而得到一个新的、记录数增1的有序表
	* 实现

			public void InsertSort (int[] arr){
				int len=arr.Length;//获取数组长度
				for(int i=1; i<len;i++){//从第二个数开始，默认第一个数已排好序
					int temp=arr[i];//取值
					int j;
					for(j=i;j>0&&arr[j-1]>temp;j--)//比较取出的值和已排好序中的值，从后往前比较
						arr[j]=arr[j-1];//若当前值小，则将前一个数移动到当前位置，j-- j移动到下一个数
					arr[j]=temp;//当不满足条件后，插入
				}
			 }

2. 希尔算法
	* 基本思想：
		* 希尔排序是把记录按下标的一定增量分组，对每组使用直接插入排序算法排序；随着增量逐渐减少，每组包含的关键词越来越多，当增量减至1时，整个文件恰被分成一组，算法便终止。
	* 实现
	
			public void ShellSort (int [] arr){
				int len=arr.Length;
				for(int gap=len/2;gap>0;gap/=2){//增量序列
					//内层嵌套插入排序
					for(int i=gap;i<len;i++){
						int temp=arr[i];
						int j;
						for(j=i;j>=gap&&arr[j-gap]>temp;j-=gap)
							arr[j]=arr[j-gap];
						arr[j]=temp;
					}
				}
			 }

## 交换类排序
1. 冒泡排序
	* 基本思想：
		* 它重复地走访过要排序的元素列，依次比较两个相邻的元素，如果他们的顺序（如从大到小、首字母从A到Z）错误就把他们交换过来。走访元素的工作是重复地进行直到没有相邻元素需要交换，也就是说该元素已经排序完成。
	* 实现
	
			public void BubbleSort(int[] arr){
				int len=arr.Length;
				for(int i=1;i<len;i++)
					for(int j=0;j<len-i;j++)
						if(arr[j]>arr[j+1]){
							int temp=arr[j];
							arr[j]=arr[j+1];
							arr[j+1]=temp;
						}
			 }
2. 快速排序
	* 基本思想：
		* 通过一趟排序将要排序的数据分割成独立的两部分，其中一部分的所有数据都比另外一部分的所有数据都要小，然后再按此方法对这两部分数据分别进行快速排序，整个排序过程可以递归进行，以此达到整个数据变成有序序列。
	* 实现
	
			public void QuickSort(int[] arr,int left,int right){
				if(left>=right) return;
				int i=left,j=right,key=arr[i];//获取最左边，最右边，和参照值
				while(i<j){
					while(i<j&&arr[j]>=key) j--;//当右边的值比参照值大时，向前移动
					if(i<j){
						int temp=arr[j];
						arr[j]=arr[i];
						arr[i]=temp;
					}//右边的值比参照值小，移动到左边
					while(i<j&&arr[i]<=key) i++;//当左边的值比参照值小时，向后移动
					if(i<j){
						int temp=arr[i];
						arr[i]=arr[j];
						arr[j]=temp;
					}//左边的值比参照值大，移到右边		
				}
				//此时ij汇合，key的左边比他小，右边比他大，在对这两个部分进行排序，以此类推
				QuickSork(arr,left,i-1);//左边部分
				QuickSork(arr,i+1,right);//右边的部分
			 }

## 选择类排序

1. 选择排序
	* 原理：
		* 首先在未排序序列中找到最小（大）元素，存放到排序序列的起始位置，然后，再从剩余未排序元素中继续寻找最小（大）元素，然后放到已排序序列的末尾。以此类推，直到所有元素均排序完毕。
	* 实现
		
			public void selectionSort(int [] arr){
				int len=arr.Length;
				for(int i=0;i<len;i++){
					for(int j=i+1;j<len-i;j++)
						if(arr[i]>arr[j]){
							int temp=arr[i];
							arr[i]=arr[j];
							arr[j]=temp;
						}
				}
			}
2. 堆排序
	* 原理：
		* 利用堆这种数据结构所设计的一种排序算法。堆是一个近似完全二叉树的结构，并同时满足堆积的**性质**：即子结点的键值或索引总是小于（或者大于）它的父节点。
	* 实现

			public void HeapSort(int [] arr){
				int len=arr.Length
				for(int i=len/2-1;i>=0;i--)
					buildMaxHeap(arr,i,len);
				for(int i=len-1;i>0;i--){
				int temp=arr[i];
				arr[i]=arr[0];
				arr[0]=temp;
				buildMaxHeap(arr,0,i);
				}
			}

			private void buildMaxHeap(int [] arr,int index,int len){
				for(int child;index>=0;index=chile){
					child=2*index+1;//获取当前节点的左子树，其中左子树为2*index+1,右子树为2*index+2
					if(chile+1<len&&arr[child]<arr[child+1]) child++;//选择两个子树中大一点的子树
					if(arr[child]>arr[index]) {//与当前根节点比较，大根堆根节点比子树大
						int temp=arr[child];
						arr[child]=arr[index];
						arr[index]=temp;
					}
					else break;
				}
			}


## 归并排序

### 原理

建立在归并操作上的一种有效的排序算法,该算法是采用分治法（Divide and Conquer）的一个非常典型的应用。将已有序的子序列合并，得到完全有序的序列；即先使每个子序列有序，再使子序列段间有序。若将两个有序表合并成一个有序表，称为二路归并。

### 实现（递归）

	public void MergeSort (int [] arr){
		int L=0,R=arr.Length-1;
		MergeSort(arr,L,R);
	}
	private void MergeSort (int [] arr,int L,int R){
		if(L<R){
			int M=(L+R)/2;//中间位置
			MergeSort(arr,L,M);//左边的集合
			MergeSort(arr,M+1,R);//右边的集合
			Merge(arr,L,M,R);//对两个集合进行排序
		}
	}
	Private void Mergen (int [] arr,int L,int M,int R){
		int len=R-L+1;//临时数组的长度
		int [] t=new int[R-L+1];//创建临时数组
		int temp=0;//临时数组的指针
		int left=L,right=M+1;//左右两边集合的起点
		while(left<=M&&right<=R){//MR为两个集合下标的最大值
			if(arr[left]>arr[right]) t[temp++]=arr[right];
			else t[temp++]=arr[left++];//将相对下的值放在前面，直到左右两个集合中的其中一个集合的值全部比对完成
		}
		//将未放入到临时数组中的值全部放入
		while(left<=M) t[temp++]=arr[left++];
		while(right<=R) t[temp++]=arr[right++];
		//将临时数组中的值赋值给原数组
		for(int i=0;i<len;i)
			arr[L+i]=t[i];//L为比对的两个比对的集合中左边集合的开始位置，故为L+i
	}