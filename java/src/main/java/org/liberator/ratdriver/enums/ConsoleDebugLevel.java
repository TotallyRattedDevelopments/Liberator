package org.liberator.ratdriver.enums;

/**
 * Level of debugging to use during testing
 */
@SuppressWarnings("unused")
public enum ConsoleDebugLevel {

    /**
     * No level specified
     */
    NotSpecified,

    /**
     * Human readable text
     */
    Human,

    /**
     * Includes the exception message
     */
    Message,

    /**
     * Includes the whole stack trace
     */
    StackTrace
}
