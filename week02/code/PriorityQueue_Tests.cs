using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities, then dequeue them
    // Expected Result: Items are returned in order of priority (highest first)
    // Defect(s) Found: The queue was not removing items after dequeueing and the loop was excluding the final item.
    public void Test_Dequeue_HighestPriorityFirst()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("Medium", 5);
        pq.Enqueue("High", 10);

        Assert.AreEqual("High", pq.Dequeue());
        Assert.AreEqual("Medium", pq.Dequeue());
        Assert.AreEqual("Low", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same highest priority
    // Expected Result: Dequeue returns them in FIFO order
    // Defect(s) Found: The queue was not removing items after dequeueing and the loop was excluding the final item.
    public void Test_Dequeue_SamePriorityFIFO()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("First", 10);
        pq.Enqueue("Second", 10);
        pq.Enqueue("Third", 5);

        Assert.AreEqual("First", pq.Dequeue());
        Assert.AreEqual("Second", pq.Dequeue());
        Assert.AreEqual("Third", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue
    // Expected Result: InvalidOperationException is thrown
    // Defect(s) Found: None
    [ExpectedException(typeof(InvalidOperationException))]
    public void Test_Dequeue_EmptyQueueThrows()
    {
        var pq = new PriorityQueue();
        pq.Dequeue();
    }

    [TestMethod]
    // Scenario: Mix of same and different priorities
    // Expected Result: Highest priority dequeued first, FIFO order for ties
    // Defect(s) Found: None
    public void Test_MixedPriorityFIFOOnTie()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 3);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 5);
        pq.Enqueue("D", 1);

        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
        Assert.AreEqual("D", pq.Dequeue());
    }
}
