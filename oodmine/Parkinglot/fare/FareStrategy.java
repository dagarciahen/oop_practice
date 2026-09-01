public interface FareStrategy {
    BigDecimal calcualteFare(Ticket ticket, BigDecimal inputFare);

}
