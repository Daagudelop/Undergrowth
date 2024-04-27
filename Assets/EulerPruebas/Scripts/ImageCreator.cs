using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ImageCreator : MonoBehaviour
{
    public List<Sprite> spritesToAdd; // Lista de sprites que se añadirán
    public float spacing = 10f; // Espacio entre las imágenes

    private EntityTeamsData entityTeamsData; // Referencia al script EntityTeamsData

    void Start()
    {
        // Obtener la instancia de EntityTeamsData
        entityTeamsData = EntityTeamsData.sharedInstanceEntityTeamsData;

        // Llamamos a la función para reconocer las entidades y crear imágenes al inicio
        RecognizeEntities();
        CreateImages();
    }

    void RecognizeEntities()
    {
        // Obtener las entidades del equipo "UnalTeam" desde EntityTeamsData
        List<Entity> unalTeamEntities = entityTeamsData.teamsMembers.ContainsKey("UnalTeam") ? entityTeamsData.teamsMembers["UnalTeam"] : new List<Entity>();

        foreach (Entity entity in unalTeamEntities)
        {
            // Obtener el sprite de la entidad (supongamos que la entidad tiene un campo sprite)
            Sprite entitySprite = entity.gameObject.GetComponent<SpriteRenderer>().sprite; // Obtener el sprite del componente SpriteRenderer

            if (entitySprite != null)
            {
                // Agregar el sprite a la lista spritesToAdd
                spritesToAdd.Add(entitySprite);
            }
        }
    }

    void CreateImages()
    {
        // Obtener el componente RectTransform del Canvas para obtener las dimensiones
        RectTransform canvasRectTransform = GetComponent<RectTransform>();
        float canvasWidth = canvasRectTransform.rect.width;
        float canvasHeight = canvasRectTransform.rect.height;

        // Recorrer la lista de spritesToAdd y crear imágenes para cada sprite
        for (int i = 0; i < spritesToAdd.Count; i++)
        {
            Sprite sprite = spritesToAdd[i];

            // Crear un nuevo objeto Image y asignarle el sprite
            GameObject newImageGO = new GameObject("Image_" + i);
            Image newImage = newImageGO.AddComponent<Image>();
            newImage.sprite = sprite;

            // Establecer el RectTransform del objeto Image para posicionarlo
            RectTransform imageRectTransform = newImageGO.GetComponent<RectTransform>();
            imageRectTransform.SetParent(canvasRectTransform); // Establecer el Canvas como padre
            imageRectTransform.localScale = Vector3.one; // Escala por defecto
            imageRectTransform.sizeDelta = new Vector2(50f, 50f); // Tamaño de la imagen (ajústalo según tus necesidades)

            // Posicionar la imagen en la esquina superior izquierda con el espacio deseado
            float xPos = spacing + (i * (imageRectTransform.sizeDelta.x + spacing));
            float yPos = -(canvasHeight / 2) + (imageRectTransform.sizeDelta.y / 2) + spacing;
            imageRectTransform.anchoredPosition = new Vector2(xPos, yPos);
        }
    }

    public void MoveFirstToLast()
    {
        if (spritesToAdd.Count > 1)
        {
            // Obtener el primer sprite de la lista y eliminarlo
            Sprite firstSprite = spritesToAdd[0];
            spritesToAdd.RemoveAt(0);

            // Agregar el sprite eliminado al final de la lista
            spritesToAdd.Add(firstSprite);

            // Llamar a la función para recrear las imágenes con la nueva lista
            RecreateImages();
        }
    }

    void RecreateImages()
    {
        // Eliminar todas las imágenes actuales del Canvas
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        // Volver a crear las imágenes con la lista actualizada de sprites
        CreateImages();
    }
}
