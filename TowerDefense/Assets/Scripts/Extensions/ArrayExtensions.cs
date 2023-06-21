using UnityEngine;

public static class ArrayExtensions
{
    public static void Shuffle(this Transform[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            var temp = array[i];
            int randomIndex = Random.Range(i, array.Length);
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }
}
