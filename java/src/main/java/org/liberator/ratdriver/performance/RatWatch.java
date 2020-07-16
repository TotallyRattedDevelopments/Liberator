package org.liberator.ratdriver.performance;

import lombok.Getter;
import lombok.Setter;
import org.javatuples.Pair;
import org.liberator.ratdriver.enums.Timing;

import java.util.LinkedList;
import java.util.List;

@SuppressWarnings("unused")
public class RatWatch {

    /**
     * Contains the timings for the current analysis cycle
     */
    @Getter
    @Setter
    public List<Pair<Timing, RatTimer>> Timings;


    /**
     * The timer currently being used
     */
    @Getter
    @Setter
    public RatTimer CurrentTimer;


    /**
     * Constructor for the RatWatch class
     */
    public RatWatch()
    {
        Timings = new LinkedList<>();
    }


    /**
     * Adds the timings from an existing watch to a new one.
     * @param ratWatch Existing watch.
     */
    public RatWatch(RatWatch ratWatch)
    {
        CurrentTimer = null;
        Timings = ratWatch.Timings;
    }


    /**
     * Creates a new timer and starts the count
     */
    public void StartTimer()
    {
        try
        {
            CurrentTimer = new RatTimer();
            CurrentTimer.Start();
        }
        catch (Exception ex)
        {
            System.out.println("Unable to start the timer");
            System.out.println(ex.getMessage());
        }
    }


    /**
     * Stops the timer and adds it to the timings list
     * @return returns the number of milliseconds
     */
    public long StopTimer()
    {
        try
        {
            CurrentTimer.Stop();
            Timings.add(new Pair<>(Timing.NotSpecified, CurrentTimer));
            return CurrentTimer.duration;
        }
        catch (Exception ex)
        {
            System.out.println("Unable to stop the timer");
            System.out.println(ex.getMessage());
            return 0;
        }
    }

    /**
     * Stops the timer and adds a specified timing point type to the timings list
     * @param timerType the type of timer to record
     */
    public void StopTimer(Timing timerType)
    {
        try
        {
            CurrentTimer.Stop();
            Timings.add(new Pair<>(timerType, CurrentTimer));
        }
        catch (Exception ex)
        {
            System.out.println("Unable to stop the timer");
            System.out.println(ex.getMessage());
        }
    }

}
