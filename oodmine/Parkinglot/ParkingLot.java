package ParkingLot;

import parkinglot.fare.FareCalculator;
import parkinglot.fare.Ticket;
import parkinglot.spot.ParkingManager;
import parkinglot.spot.ParkingSpot;
import parkinglot.vehicle.Vehicle;

import java.math.BigDecimal;
import java.time.LocalDateTime;

//facada leave complex operator to parkingmanager hwile is a an interface from user to parkin
public class ParkingLot {
    private final ParkingManager parkingManager;
    private final FareCalculator fareCalculator;

    public ParkingLot(ParkingManager parkingManager, FareCalculator farecalculator) {
        this.parkingManager = parkingManager;
        this.fareCalculator = fareCalculator;

    }
        // Method to handle vehicle entry into the parking lot
    public Ticket enterVehicle(Vehicle vehicle) {
        // Delegate parking logic to ParkingManager
        ParkingSpot spot = parkingManager.parkVehicle(vehicle);
        
        if (spot != null) {
            // Create ticket with entry time
            Ticket ticket = new Ticket(generateTicketId(), vehicle, spot, LocalDateTime.now());
            return ticket;
        } else {
            return null;  // No spot available
        }
    }

    // Method to handle vehicle exit from the parking lot using the parkinglot.fare.Ticket object
    public void leaveVehicle(Ticket ticket) {
        if (ticket != null && ticket.getExitTime() == null) {  // Ensure the ticket is valid and the vehicle hasn't already left
            // Set exit time
            ticket.setExitTime(LocalDateTime.now());
            
            // Delegate unparking logic to ParkingManager
            parkingManager.unparkVehicle(ticket.getVehicle());

            // Calculate the fare
            BigDecimal fare = fareCalculator.calculateFare(ticket);
        } else {
            // Invalid ticket or vehicle already exited. 
        }
    }

    // Helper method to generate a unique ticket ID
    private String generateTicketId() {
        return "TICKET-" + System.currentTimeMillis();
    }
}
}