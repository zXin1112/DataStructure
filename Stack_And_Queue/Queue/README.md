# 队列

## 基本特征
只允许在一端进行插入操作，在另一端进行删除操作的线性表，先进先出（first in first out）。其中插入的一端为队尾，删除的一端为队头

## 基本操作
![](https://i.imgur.com/415DfFN.png)

* 入队 
	* 将数据元素插入队尾
* 出队
	* 读取队头元素并删除

## 循环队列
### 应用场景
当使用数组来实现队列时，在数组容量固定的情况下，进行几次出队操作后，队头之前会出现空闲位置，而队尾指针指向末尾，此时在插入元素，队尾指针指向哪里？
![](https://i.imgur.com/RllCmZQ.png)

所以为了解决这个问题，使用循环队列，即头尾循环。

### 在使用循环队列时，应注意的问题
* 队头队尾指针如何确定
	* 可借助%对head和tail两个指针进行位置确定
	* 例
	
			// 移动队尾指针
			tail = (tail + 1) % item.Length;
			// 移动队头指针
			head = (head + 1) % item.Length; 
* 如何判断队列空还是满
	* 当队列空时，条件就是head=tail，当队列满时，我们修改其条件，保留一个元素空间。也就是说，队列满时，数组中还有一个空闲单元。
 ![](https://i.imgur.com/nFMfFwY.png)
	* 从上图可以看出，由于tail可能比head大，也可能比head小，所以尽管它们只相差一个位置时就是满的情况，但也可能是相差整整一圈。所以若队列的最大尺寸为QueueSize，那么队列满的条件是 **(tail+1)%QueueSize==head**（取模“%”的目的就是为了整合tail与head大小为一个问题）。
* 由于tail可能比head大，也可能比head小，那么队列的长度如何计算？
	* 当tail>head时，此时队列的长度为tail-head。但当tail<head时，队列长度分为两段，一段是QueueSize-head，另一段是0+tail，加在一起，队列长度为tail-head+QueueSize。因此通用的计算队列长度公式为：**(tail-head+QueueSize)%QueueSize**。

