module ca.georgiancollege.comp1011m2022ice5 {
    requires javafx.controls;
    requires javafx.fxml;
    requires java.sql;

    //Warning: Don't delete this part by accident
    opens ca.georgiancollege.comp1011m2022ice5 to javafx.fxml;
    exports ca.georgiancollege.comp1011m2022ice5;
}