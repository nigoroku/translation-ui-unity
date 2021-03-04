using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    public class InteractionTest
    {
        [SetUp]
        public void SetUp()
        {
            SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        }

        [TearDown]
        public void TearDown()
        {
            SceneManager.UnloadSceneAsync("MainScene");
        }

        private class MonoBehaviour_TestScenario : MonoBehaviour, IMonoBehaviourTest
        {
            private Renderer cubeRenderer;

            public bool IsTestFinished { get; private set; }

            private void Start()
            {
                cubeRenderer = GameObject.Find("Cube").GetComponent<Renderer>();
            }

            private void Update()
            {
                if (cubeRenderer.material.color == Color.red)
                    IsTestFinished = true;
            }
        }

        [UnityTest]
        public IEnumerator ボタンを押すとCubeが赤くなる()
        {
            yield return new MonoBehaviourTest<MonoBehaviour_TestScenario>();
        }
    }
}
