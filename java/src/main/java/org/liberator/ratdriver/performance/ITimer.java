package org.liberator.ratdriver.performance;

import lombok.Getter;
import lombok.Setter;

import java.time.Instant;
import java.util.Date;

public interface ITimer {
    /**
     * Start the timer
     */
    void Start();

    /**
     * Stop the timer
     */
    void Stop();
}
