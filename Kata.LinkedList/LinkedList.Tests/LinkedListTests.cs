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
        public void add_to_the_front_to_an_empty_list_should_be_head_and_tail()
        {
            var list = new LinkedList<int>();

            list.AddFirst(1);

            Assert.AreEqual(1, list.Head.Value);
            Assert.AreEqual(1, list.Tail.Value);
        }

        [Test]
        public void add_to_the_front_to_an_existing_list_should_be_head_and_not_tail()
        {
            var list = new LinkedList<int>();

            list.AddFirst(1);
            list.AddFirst(2);

            Assert.AreEqual(2, list.Head.Value);
            Assert.AreEqual(1, list.Tail.Value, "Tail value does not match");
        }

        [Test]
        public void add_to_the_end_to_an_empty_list_should_be_head_and_tail()
        {
            var list = new LinkedList<int>();

            list.AddLast(1);

            Assert.AreEqual(1, list.Head.Value);
            Assert.AreEqual(1, list.Tail.Value);
        }

        [Test]
        public void add_to_the_end_to_an_existing_list_should_be_tail_and_not_head()
        {
            var list = new LinkedList<int>();

            list.AddLast(1);
            list.AddLast(2);

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

            list.AddFirst(one);
            list.AddBefore(list.Head, one);

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
    }
}
