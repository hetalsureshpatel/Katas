using System.Linq;
using NUnit.Framework;

namespace LinkedList.Tests
{
    [TestFixture]
    public class LinkedListTests
    {
        [Test]
        public void an_empty_list_should_not_have_a_head_or_tail()
        {
            var list = new LinkedList<int>();

            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
        }

        [Test]
        public void add_to_the_head_to_an_empty_list_should_be_head_and_tail()
        {
            var list = new LinkedList<int>();

            list.AddHead(1);

            Assert.AreEqual(1, list.Head.Value);
            Assert.AreEqual(1, list.Tail.Value);
        }

        [Test]
        public void add_to_the_head_to_an_existing_list_should_be_head_and_not_tail()
        {
            var list = new LinkedList<int>();

            list.AddHead(1);
            list.AddHead(2);

            Assert.AreEqual(2, list.Head.Value);
            Assert.AreEqual(1, list.Tail.Value, "Tail value does not match");
        }

        [Test]
        public void add_to_the_tail_to_an_empty_list_should_be_head_and_tail()
        {
            var list = new LinkedList<int>();

            list.AddTail(1);

            Assert.AreEqual(1, list.Head.Value);
            Assert.AreEqual(1, list.Tail.Value);
        }

        [Test]
        public void add_to_the_tail_to_an_existing_list_should_be_tail_and_not_head()
        {
            var list = new LinkedList<int>();

            list.AddTail(1);
            list.AddTail(2);

            Assert.AreEqual(1, list.Head.Value, "head value does not match");
            Assert.AreEqual(2, list.Tail.Value);
        }

        [Test]
        public void add_item_before_head_to_an_empty_list_should_become_head_and_tail()
        {
            var list = new LinkedList<int>();
            var one = 1;

            list.AddBefore(list.Head, one);

            Assert.AreEqual(one, list.Head.Value);
            Assert.AreEqual(one, list.Tail.Value);
        }

        [Test]
        public void add_item_before_head_to_an_existing_list_should_become_head_and_not_tail()
        {
            var list = new LinkedList<int>();
            var one = 1;
            var two = 2;

            list.AddHead(one);
            list.AddBefore(list.Head, two);

            Assert.AreEqual(two, list.Head.Value);
            Assert.AreEqual(one, list.Tail.Value);
        }

        [Test]
        public void add_item_before_tail_to_an_empty_list_should_become_head_and_tail()
        {
            var list = new LinkedList<int>();
            var one = 1;

            list.AddBefore(list.Head, one);

            Assert.AreEqual(one, list.Head.Value);
            Assert.AreEqual(one, list.Tail.Value);
        }

        [Test]
        public void add_to_the_head_four_items_count_should_be_four()
        {
            var list = new LinkedList<int>();
            var one = 1;
            var two = 2;
            var three = 3;
            var four = 4;

            list.AddHead(one);
            list.AddHead(two);
            list.AddHead(three);
            list.AddHead(four);

            Assert.AreEqual(4, list.Count);
        }

        [Test]
        public void add_to_the_tail_four_items_count_should_be_four()
        {
            var list = new LinkedList<int>();
            var one = 1;
            var two = 2;
            var three = 3;
            var four = 4;

            list.AddTail(one);
            list.AddTail(two);
            list.AddTail(three);
            list.AddTail(four);

            Assert.AreEqual(4, list.Count);
        }

        [Test]
        public void add_item_in_middle_of_a_list_should_appear_in_the_correct_order()
        {
            var list = new LinkedList<int>();
            var one = 1;
            var two = 2;
            var three = 3;

            list.AddHead(one);
            list.AddTail(three);

            list.AddBefore(list.Tail, two);

            var result = list.ToList();

            Assert.AreEqual(one, list.Head.Value);
            Assert.AreEqual(two, result[1]);
            Assert.AreEqual(three, list.Tail.Value);
        }

        [Test]
        public void should_be_able_to_clear_an_existing_list()
        {
            var list = new LinkedList<int>();

            list.AddHead(1);
            list.AddHead(2);
            list.AddHead(3);

            list.Clear();

            Assert.AreEqual(0, list.Count);
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
        }

        [Test]
        public void remove_item_by_value_should_be_removed_from_list()
        {
            var list = new LinkedList<int>();

            list.AddHead(2);
            list.AddHead(1);

            var isRemoved = list.Remove(2);

            var result = list.ToList();

            Assert.AreEqual(1, list.Count);
            Assert.IsTrue(isRemoved, "The value 2 was not removed from list.");
            Assert.IsFalse(result.Any(i => i == 2), "The value 2 was not removed from list.");
        }

        [Test]
        public void remove_item_by_value_from_an_empty_list_should_not_have_removed_item_from_list()
        {
            var list = new LinkedList<int>();


            var isRemoved = list.Remove(2);

            Assert.AreEqual(0, list.Count);
            Assert.IsFalse(isRemoved, "No item should have been removed.");
        }
    }
}
