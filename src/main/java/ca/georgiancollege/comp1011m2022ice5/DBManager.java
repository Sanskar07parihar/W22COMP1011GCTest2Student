/**
 *   Name - Diya Diya
 *   Student number - 200489015
 *   Course - COMP 1011
 *   Semester - 3
 */

package ca.georgiancollege.comp1011m2022ice5;

import javafx.scene.chart.XYChart;

import java.sql.*;
import java.util.ArrayList;

/*Singleton*/
public class DBManager
{
    /******************** SINGLETON SECTION *************************************/
   // Step 1. private static instance member
    private static DBManager m_instance = null;
    //Step. make the default constructor private
    private DBManager() {}
    //Step 3. create public static entry point / instance method that allows entry in the class and access
    public static DBManager Instance()
    {
        //Step 4. Check if the private instance member variable is null
        if(m_instance == null)
        {
            //Step 5. Instantiate a new DBManager instance
            m_instance = new DBManager();
        }
        return m_instance;
    }
    /*******************************************************************************/

    //private instance member variables
    private String m_user = "root";
    private String m_password = "Di131316@";
    private String m_connectURL = "jdbc:mysql://127.0.0.1:3306/comp1011m2022";

    /**
     * This method inserts a Vector2D object to the Database
     *
     * @param vector2D
     * @return
     * @throws SQLException
     */
    public int insertVector2D(Vector2D vector2D) throws SQLException {
        //This is almost a kind of confirmation that every thing works well
        int vectorID = -1;// if this method returns -1 - it means that something went wrong

        // initializing the result set object
        ResultSet resultSet = null;

        //create a query string
        // ? is a placeholder for what we are going to insert
        String sql = "INSERT INTO vectors(X, Y, Magnitude) VALUES(?, ?, ?);";

        try
                        ( /* head of the try / catch block */
                        Connection connection = DriverManager.getConnection(m_connectURL, m_user, m_password);
                        PreparedStatement statement = connection.prepareStatement(sql, new String[] { "vectorID" });

                        )
        {

            //configure the prepared statement
            statement.setFloat(1, vector2D.getX());
            statement.setFloat(2, vector2D.getY());
            statement.setFloat(3, vector2D.getMagnitude());

            //run the command on the Database
            statement.executeUpdate();

            // get the VectorID
            resultSet = statement.getGeneratedKeys();
            while (resultSet.next())
            {
                // get the VectorID from the Database
                vectorID = resultSet.getInt(1);
            }
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
        finally {
            if (resultSet != null)
            {
                resultSet.close();
            }
        }
        return vectorID;

    }

    /**
     * This method reads the vectors table from the MySQL database
     * and returns an ArrayList of Vector2D type
     * @return
     */
    //How we can read our data from the database. When we read from the database it's kind of we are reading data from a list of arrays(Vector2D Arraylist)
    public ArrayList<Vector2D> readVectorTable()
    {
        //It would have the same structure as Vector2D

        //Instantiates an ArrayList collection of type Vector2D (empty container)
        ArrayList<Vector2D> vectors = new ArrayList<Vector2D>();

        String sql = "SELECT vectors.vectorID, X, Y FROM vectors GROUP BY vectors.vectorID";

        try (Connection connection = DriverManager.getConnection(m_connectURL, m_user, m_password);
        Statement statement = connection.createStatement();
        ResultSet resultSet = statement.executeQuery(sql);
        )

        {
            // while there is another record...loop
           while(resultSet.next())
           {
               // deserialize (decode) the data from database table
               int vectorID = resultSet.getInt("VectorID");
               float X = resultSet.getFloat("X");
               float Y = resultSet.getFloat("Y");

               // create an anonymous Vector2D object with the data from the database
               // then add the new Vector2D object to the vectors ArrayList
               vectors.add(new Vector2D(vectorID, X, Y));
           }
        }
        catch (Exception exception)
        {
            exception.printStackTrace();
        }

        return vectors;
    }

    /**
     * This method returns the Bar Chart Data from the Database
     * @return
     */
    public XYChart.Series<String, Float> getMagnitude()
    {
        // Step 1. Create a Series
        XYChart.Series<String, Float> magnitudes = new XYChart.Series<>();
        magnitudes.setName("2022");
        // Step 2. Get the Data from the Database
        ArrayList<Vector2D> vectors = readVectorTable();

        // Mock Data example
        /*
        magnitudes.getData().add(new XYChart.Data<>("0, 0",0.0f));
        magnitudes.getData().add(new XYChart.Data<>("10, 20",10.0f));
        magnitudes.getData().add(new XYChart.Data<>("30, 40",20.0f));
        magnitudes.getData().add(new XYChart.Data<>("50, 60",30.0f));
        */

        // Step 3. For each Vector in the Data...Loop and add it to the Series
        for (var vector : vectors)
        {
            var chartData = new XYChart.Data<>(vector.toOneDecimalString(), vector.getMagnitude());
            magnitudes.getData().add(chartData);
        }

        // We are returning magnitudes because it is of the type that we need to return
        return magnitudes;
    }
}
