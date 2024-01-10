package com.example;

import org.apache.wicket.markup.html.WebPage;
import org.apache.wicket.protocol.http.WebApplication;
import org.apache.wicket.request.mapper.parameter.PageParameters;
import org.apache.wicket.request.resource.StringResource;

public class HelloApiController extends WebPage {

    public HelloApiController(final PageParameters parameters) {
        super(parameters);
    }

    public static class RestResource extends StringResource {
        @Override
        protected String getString() {
            // Here you can generate your JSON response
            return "{\"message\":\"Hello, API!\"}";
        }
    }

    public static class HelloApiApplication extends WebApplication {

        @Override
        public Class<? extends WebPage> getHomePage() {
            return HelloApiController.class;
        }

        @Override
        public void init() {
            super.init();
            mountResource("/api/hello", new RestResource());
        }
    }

    public static void main(String[] args) {
        // Start the Wicket application using its built-in server
        new HelloApiApplication().run();
    }
}
