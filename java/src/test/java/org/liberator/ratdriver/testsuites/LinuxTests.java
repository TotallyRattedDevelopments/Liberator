package org.liberator.ratdriver.testsuites;

import org.junit.runner.RunWith;
import org.junit.runners.Suite;
import org.liberator.ratdriver.tests.*;

@RunWith(Suite.class)

@Suite.SuiteClasses(
        {
                ChromeTests.class,
                FirefoxTests.class,
                OperaTests.class
        }
)
public class LinuxTests {
}
