using UnityEngine.UI;

public class SelectTheme : EnsinaRunnerController
{
    public Dropdown myDropdown;
    public static int themeValue = 0;

    void Update()
    {
        ThemeReturn();
    }

    // Retorna o int dos temas.
    public int ThemeReturn()
    {
        switch (myDropdown.value)
        {
            case 0:
                themeValue = 0;     // 0 = Escolha um Tema...
                break;
            case 1:
                themeValue = 1;     // 1 = Lógica para computação
                break;
            case 2:
                themeValue = 2;     // 2 = Matemática
                break;
        }

        return themeValue;
    }
}