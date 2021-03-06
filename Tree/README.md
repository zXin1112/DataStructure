# 树与二叉树

## 树
### 基本概念

树是n(n>=0)个节点的有限集.n=0时，是空树。

### 基本术语

* 不同的节点：根节点、内部节点、叶子节点以及节点的度

![](https://i.imgur.com/6grPxRw.png)

**注意**： 度是该节点子树的数目

* 节点关系：双亲与孩子

![](https://i.imgur.com/cpLzo6L.png)

* 节点层次：从根开始定义起，根为第一层，根的孩子为第二层。树中结点的最大层次称为树的深度。

![](https://i.imgur.com/omuDChI.png) 


## 二叉树
### 特点
1. 每个节点最多有两颗子树，所以二叉树中节点的度最大为2
2. 左子树和右子树是有顺序的，次序不能随意颠倒
3. 即使只有一颗子树，也要区分左子树还是右子树

### 二叉树的顺序存储结构
二叉树的顺序存储结构就是用一维数组存储二叉树中的结点。

![](https://i.imgur.com/anV7dBN.png)

**注意**： 考虑一种极端的情况，一棵深度为k的右斜树，它只有k个结点，却需要分配2的k次方-1个存储单元空间，这显然是对存储空间的浪费，所以，顺序存储结构一般只适用于完全二叉树。

###  二叉树的链式存储结构

二叉树每个结点最多有两个孩子，所以为它设计一个数据域和两个指针域，这种链式存储结构的链表叫做二叉链表。其中data是数据域，lchild和rchild都是指针域，分别存放指向左孩子和右孩子的指针。

![](https://i.imgur.com/UnbhCLM.png)

### 二叉树的递归遍历
二叉树有三种基本遍历：前序、中序、后序

1. 前序:
	* 若节点不为空，先序遍历根节点，然后是左子树，最后是右子树（根左右）
	
		![](https://i.imgur.com/CnpxBsI.png)
2. 中序：
	* 若根节点不为空，中序遍历左子树，然后是根节点，最后右子树（左根右）
	
		![](https://i.imgur.com/Z0JQ2ZR.png)
3. 后序：
	*  若根节点不为空，后序遍历左子树，然后右子树，最后根节点（左右根）
		
		![](https://i.imgur.com/2Of5Elk.png)

### 二叉树的非递归遍历
1. 前序：（根左右）
	* 利用了栈先进后出，先遍历显示根节点，然后将右子树压栈，最后是左子树压栈，由于最后将左子树压栈，故下一次先出栈的是左子树，保证了根左右的顺序

			   public static void PreOrderNoRecurise<T>(this MyBinaryTree<T> myBinary)
		        {
		            if (myBinary.Root == null) return;//检查根节点
		            Stack<Node<T>> stack = new Stack<Node<T>>();
		            stack.Push(myBinary.Root);//根节点入栈
		            Node<T> tempnode = null;
		            while (stack.Count > 0)
		            {
		                tempnode = stack.Pop();
		                Console.Write("{0} ", tempnode.data);
		                if (tempnode.rchild != null)//检查右子树
		                    stack.Push(tempnode.rchild);//出栈的顺序为先进后出，为了输出为根=>左=>右，这里先让右子树进栈，
		                if (tempnode.lchild != null)//再让左子树进栈,使得循环时保证了左子树先出栈
		                    stack.Push(tempnode.lchild);
		            }
		        }
2. 中序：（左根右）
	* 首先将所有左子树压栈，然后顺序出栈，每出一个元素，便将其右子树压栈，这样保证了左根右的顺序
	
				public static void MidOrderNoRecurise<T>(this MyBinaryTree<T> myBinary)
			        {
			            if (myBinary.Root == null) return;//检查根节点
			            Stack<Node<T>> stack = new Stack<Node<T>>();
			            Node<T> tempnode = myBinary.Root;
			
			            while (tempnode != null || stack.Count > 0)
			            {
			
			                while (tempnode != null)//将所有左子树遍历入栈
			                {
			                    stack.Push(tempnode);
			                    tempnode = tempnode.lchild;
			                }
			                tempnode = stack.Pop();
			                Console.Write("{0} ", tempnode.data);
			
			                tempnode = tempnode.rchild;//右子树入栈
			            }
			        }
3. 后序：（左右根）
	* 使用两个栈，其中stackIn过渡作用，stackOut为输出，先按照根节点->左孩子->右孩子的顺序依次压栈，那么其出栈顺序就是右孩子->左孩子->根节点。而每当循环一次就会从stackIn中出栈一个元素，并压入stackOut中，那么这时stackOut中的出栈顺序则变成了左孩子->右孩子->根节点的顺序
	 
				 public static void PostOrderNoRecurise<T>(this MyBinaryTree<T> myBinary)
			        {
			            if (myBinary.Root == null) return;//检查根节点
			            Stack<Node<T>> stackIn = new Stack<Node<T>>();//暂时存储的栈 
			            Stack<Node<T>> stackOut = new Stack<Node<T>>();//向外输出的栈 栈内节点顺序 根=》右=》左
			            stackIn.Push(myBinary.Root);
			
			            Node<T> currentNode = null;
			
			            while (stackIn.Count > 0)
			            {
			                currentNode = stackIn.Pop();
			                stackOut.Push(currentNode);
			
			                if (currentNode.lchild != null)//输出左右根，故在stackOut栈中的顺序为根右左
			                    stackIn.Push(currentNode.lchild);//为保证向stackOut压入根左右
			                if (currentNode.rchild != null) //先将左子树压入stackIn，在压入右子树，
			                    stackIn.Push(currentNode.rchild);//使得stackIn栈弹出时先弹出右子树,在弹出左子树 
			
			            }
			            while (stackOut.Count > 0)//出栈
			                Console.Write("{0} ", stackOut.Pop().data);
			        }
4. 层次：
	* 使用了一个队列来辅助实现，队列先进先出的，与栈刚好相反，所以只需要按照根节点->左孩子->右孩子的入队顺序依次入队，输出时就可以符合根节点->左孩子->右孩子的规则了。 

				 public static void LevelOrder<T>(this MyBinaryTree<T> myBinary)
			        {
			            if (myBinary.Root == null) return;
			            Queue<Node<T>> queueNodes = new Queue<Node<T>>();//队列 先进先出
			            queueNodes.Enqueue(myBinary.Root);//根节点
			            Node<T> tempNode = null;
			            while (queueNodes.Count > 0)
			            {
			                tempNode = queueNodes.Dequeue();//出队
			                Console.Write("{0} ", tempNode.data);
			
			                if (tempNode.lchild != null)//使用队列，依次入队
			                    queueNodes.Enqueue(tempNode.lchild);
			                if (tempNode.rchild != null)
			                    queueNodes.Enqueue(tempNode.rchild);
			            }
			        }

		![](https://i.imgur.com/i0ZiXHX.png)


### 二叉查找树
* 性质
	* 若左子树不为空，则左子树上所有节点都小于他的根节点
	* 若右子树不为空，则右子树上所有节点都大于等于他的根节点
	* 左右子树也分别为二叉查找树
	* 没有键值相等的节点
对于二叉查找树，只要进行一次中序遍历便可以得到一个排序后的结果

#### 实现
1. 若当前的二叉查找树为空时，则插入的元素为根节点
2. 若插入的元素值小于根节点时，则将元素插入到左子树中
3. 若插入的元素值大于根节点时，则将元素插入到右子树中

		 public void InsertNode(int data)
        {
            Node<int> newnode = new Node<int>(data);
          

            if (root == null) root = newnode;
            else
            {
                Node<int> currentNode = root;
                Node<int> parentNode = null;
                while (currentNode != null)
                {
                    parentNode = currentNode;
                    if (currentNode.data < data) currentNode = currentNode.rchild;//新节点比当前节点大时，往右子树找下一个节点
                    else currentNode = currentNode.lchild;//否则去左子树
                }
                //循环执行完毕后，找到了叶子结点
                if (parentNode.data < data) parentNode.rchild = newnode;//新节点大于叶子结点时，新节点作为叶子结点的右子树
                else parentNode.lchild = newnode;//新节点小于叶子结点时，新节点作为叶子结点的左子树
            }
        }


### 二叉树表达四则运算

* 特点
	1. 操作数都是叶子结点
	2. 运算符都是内部结点
	3. 优先运算的操作符在树下方，相对优先级低的最后算

* 构造方法
	* 第一个节点先成为表达式树的根
	* 第二个节点插入时变为根节点，原根节点变为新节点的左孩子
	* 插入节点为数字时，沿着根节点右子树插入最右端
	* 插入节点为操作符时，先跟根节点操作符进行对比，分两种情况处理
		* 当优先级不高时，新节点成为根节点，原表达式树成为新结点的左子树
		* 当优先级较高时，新节点成为根节点的右孩子。原根节点右子树成为新节点的左子树
