using NUnit.Framework;
using BowlingGame.DAL.Models;
using System.Collections.Generic;

namespace BowlingGameTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestFullGame1()
        {
            var scoreCard = new ScoreCardDTO()
            {
                Id = 0,
                Frames = new List<FrameDTO>() {
                    new FrameDTO()
                    {
                        Shot1 = 'x',
                        FrameNumber = 1,

                    },
                    new FrameDTO()
                    {
                        Shot1 = '7',
                        Shot2 = '/',
                        FrameNumber = 2,

                    },
                    new FrameDTO()
                    {
                        Shot1 = '7',
                        Shot2 = '2',
                        FrameNumber = 3,

                    },
                    new FrameDTO()
                    {
                        Shot1 = '9',
                        Shot2 = '/',
                        FrameNumber = 4,

                    },
                    new FrameDTO()
                    {
                        Shot1 = 'x',
                        FrameNumber = 5,

                    },
                    new FrameDTO()
                    {
                        Shot1 = 'x',
                        FrameNumber = 6,

                    },
                    new FrameDTO()
                    {
                        Shot1 = 'x',
                        FrameNumber = 7,

                    },
                    new FrameDTO()
                    {
                        Shot1 = '2',
                        Shot2 = '3',
                        FrameNumber = 8,

                    },
                    new FrameDTO()
                    {
                        Shot1 = '6',
                        Shot2 = '/',
                        FrameNumber = 9,

                    },
                    new FrameDTO()
                    {
                        Shot1 = '7',
                        Shot2 = '/',
                        Shot3 = '3',
                        FrameNumber = 10,

                    },
                }
            };

               

            Assert.AreEqual(168, scoreCard.Score);
        }
        [Test]
        public void TestFullGame2()
        {
            var scoreCard = new ScoreCardDTO()
            {
                Id = 0,
                Frames = new List<FrameDTO>() {
                    new FrameDTO()
                    {
                        Shot1 = '8',
                        Shot2 = '0',
                        FrameNumber = 1,

                    },
                    new FrameDTO()
                    {
                        Shot1 = '7',
                        Shot2 = '0',
                        FrameNumber = 2,

                    },
                    new FrameDTO()
                    {
                        Shot1 = '5',
                        Shot2 = '3',
                        FrameNumber = 3,

                    },
                    new FrameDTO()
                    {
                        Shot1 = '9',
                        Shot2 = '/',
                        FrameNumber = 4,

                    },
                    new FrameDTO()
                    {
                        Shot1 = '9',
                        Shot2= '/',
                        FrameNumber = 5,

                    },
                    new FrameDTO()
                    {
                        Shot1 = 'x',
                        FrameNumber = 6,

                    },
                    new FrameDTO()
                    {
                        Shot1 = '8',
                        Shot2= '0',
                        FrameNumber = 7,

                    },
                    new FrameDTO()
                    {
                        Shot1 = '5',
                        Shot2 = '1',
                        FrameNumber = 8,

                    },
                    new FrameDTO()
                    {
                        Shot1 = '3',
                        Shot2 = '/',
                        FrameNumber = 9,

                    },
                    new FrameDTO()
                    {
                        Shot1 = '9',
                        Shot2 = '0',
                        FrameNumber = 10,

                    },
                }
            };



            Assert.AreEqual(122, scoreCard.Score);
        }
        [Test]
        public void TestFullGame3()
        {
            var scoreCard = new ScoreCardDTO()
            {
                Id = 0,
                Frames = new List<FrameDTO>() {
                    new FrameDTO()
                    {
                        Shot1 = '8',
                        Shot2= '/',

                        FrameNumber = 1,

                    },
                    new FrameDTO()
                    {
                        Shot1 = '9',
                        Shot2 = '0',
                        FrameNumber = 2,

                    },
                    new FrameDTO()
                    {
                        Shot1 = '4',
                        Shot2 = '4',
                        FrameNumber = 3,

                    },
                    new FrameDTO()
                    {
                        Shot1 = '7',
                        Shot2 = '2',
                        FrameNumber = 4,

                    },
                    new FrameDTO()
                    {
                        Shot1 = '9',
                        Shot2='0',
                        FrameNumber = 5,

                    },
                    new FrameDTO()
                    {
                        Shot1 = 'x',
                        FrameNumber = 6,

                    },
                    new FrameDTO()
                    {
                        Shot1 = 'x',
                        FrameNumber = 7,

                    },
                    new FrameDTO()
                    {
                        Shot1 = '8',
                        Shot2 = '0',
                        FrameNumber = 8,

                    },
                    new FrameDTO()
                    {
                        Shot1 = '3',
                        Shot2 = '5',
                        FrameNumber = 9,

                    },
                    new FrameDTO()
                    {
                        Shot1 = '9',
                        Shot2 = '/',
                        Shot3 = '7',
                        FrameNumber = 10,

                    },
                }
            };


            Assert.AreEqual(133, scoreCard.Score);
        }

        [Test]
        public void TestPartial()
        {
            var scoreCard = new ScoreCardDTO()
            {
                Id = 0,
                Frames = new List<FrameDTO>() {
                    new FrameDTO()
                    {
                        Shot1 = 'x',
                        FrameNumber = 1,

                    },
                    new FrameDTO()
                    {
                        Shot1 = '7',
                        Shot2 = '/',
                        FrameNumber = 2,

                    },
                    new FrameDTO()
                    {
                        Shot1 = '7',
                        Shot2 = '2',
                        FrameNumber = 3,

                    },
                }
            };

            Assert.AreEqual(46, scoreCard.Score);
        }
    }
}