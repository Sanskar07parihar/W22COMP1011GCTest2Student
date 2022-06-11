/**
 *
 * Name - Diya Diya
 * Student number - 200489015
 * Course - COMP 1011
 * Semester - 3
 *
 * */


package ca.georgiancollege.comp1011m2022ice5;


import javafx.scene.control.Label;
import javafx.scene.control.Spinner;
import javafx.scene.control.SpinnerValueFactory;
import javafx.scene.control.TextField;


/* Singleton */
public class Utility
{
    //Step 1. Create a private static instance member
    private static Utility m_instance = null;

    //Step 2. - Make the default constructor private
    private Utility() {}

    // Step 3. Create a public static access method that returns a reference (an instance) to the class
    public static Utility Instance()
    {
        // Step 4. Ensure that your instance member variable has not been instantiated
        if (m_instance == null)
        {
            // Step 5. create an instance of the class and save a reference int the private variable
            m_instance = new Utility();
        }
        // Step 6. return an instance (reference) of the class
        return m_instance;
    }

    /*
     * This method returns the distance from start to end
     * @param start = start vector2D
     * @param end = ending vector2D
     * */
    public  float distance(Vector2D start, Vector2D end)
    {
        float diffXs = end.getX() - start.getX();
        float diffYs = end.getY() - start.getY();
        return (float) Math.sqrt(diffXs * diffXs + diffYs * diffYs);
    }

    public  float distance(float x1, float y1, float x2, float y2)
    {
        float diffXs = x2 - x1;
        float diffYs = y2 - y1;
        return (float) Math.sqrt(diffXs * diffXs + diffYs * diffYs);
    }

    /**
     * This is a helper method that configures a spinner of type Double for a Vector2D component (e.g. x or y)
     * @param spinner
     * @param min
     * @param max
     * @param default_value
     * @param increment_value
     */
    //This is a helper method(function) which helps us to get the spinners work rather than repeating the lambda expression over and over again
    public void configureVector2DSpinner(Spinner<Double> spinner, double min, double max, double default_value, double increment_value)
    {
        // configure each spinner
        // Step 1. Define a SpinnerValueFactory
        SpinnerValueFactory<Double> spinnerValueFactory = new SpinnerValueFactory.DoubleSpinnerValueFactory(min, max, default_value, increment_value);
        // Step 2. Set Value factory
        spinner.setValueFactory(spinnerValueFactory);
        // Step 3. get access to the spinner's TextField
        TextField spinnerTextField = spinner.getEditor();

        //Step 4. create an Event Listener / Event Handler -> Observer Pattern

        spinnerTextField.textProperty().addListener((observable, oldValue, newValue) ->
        {
            try {
                Float.parseFloat(newValue);
            }
            catch (Exception e)
            {
                spinnerTextField.setText(oldValue);
            }
        });
    }

}

