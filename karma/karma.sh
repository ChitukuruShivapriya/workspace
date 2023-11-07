#!/bin/bash
export CHROME_BIN=/usr/bin/chromium
if [ ! -d "/home/coder/project/workspace/angularapp" ]
then
    cp -r /home/coder/project/workspace/karma/angularapp /home/coder/project/workspace/;
fi



if [ -d "/home/coder/project/workspace/angularapp" ]
then
    echo "project folder present"
    cp /home/coder/project/workspace/karma/karma.conf.js /home/coder/project/workspace/angularapp/karma.conf.js;

    # checking for job-application.model component
    if [ -d "/home/coder/project/workspace/angularapp/src/models" ]
    then
        cp /home/coder/project/workspace/karma/user.model.spec.ts /home/coder/project/workspace/angularapp/src/models/user.model.spec.ts;
    else
        echo "Frontend_should_create_User_instance FAILED";
    fi

    # checking for registration.component.spec component
    if [ -d "/home/coder/project/workspace/angularapp/src/app/registration" ]
    then
        cp /home/coder/project/workspace/karma/registration.component.spec.ts /home/coder/project/workspace/angularapp/src/app/registration/registration.component.spec.ts;
    else
        echo "Frontend_should_show_username_required_error_message_on_register_page_RegistrationComponent FAILED";
        echo "Frontend_should_show_password_required_error_message_on_register_page_RegistrationComponent FAILED";
        echo "Frontend_should_show_password_complexity_error_message_on_register_page_RegistrationComponent FAILED";
        echo "Frontend_should_show_confirm_password_required_error_message_on_register_page_RegistrationComponent FAILED";
        echo "Frontend_should_show_passwords_mismatch_error_message_on_register_page_RegistrationComponent FAILED";
        
    fi

    # checking for LoginComponent component
    if [ -d "/home/coder/project/workspace/angularapp/src/app/login" ]
    then
        cp /home/coder/project/workspace/karma/login.component.spec.ts /home/coder/project/workspace/angularapp/src/app/login/login.component.spec.ts;
    else
        echo "Frontend_LoginComponent FAILED";
        echo "Frontend_call_login_method_on_admin_login_LoginComponent FAILED";
        echo "Frontend_should_call_login_method_on_customer_login_LoginComponent FAILED";
        echo "Frontend_should_have_empty_username_and_password_initially_LoginComponent FAILED";
        echo "Frontend_should_call_login_method_on_form_submission_LoginComponent FAILED";
        echo "Frontend_should_show_username_required_error_message_LoginComponent FAILED";
        echo "Frontend_should_show_password_required_error_message_LoginComponent FAILED";
    fi

    # checking for customer.service.spec component
    if [ -d "/home/coder/project/workspace/angularapp/src/app/services" ]
    then
        cp /home/coder/project/workspace/karma/customer.service.spec.ts /home/coder/project/workspace/angularapp/src/app/services/customer.service.spec.ts;
    else
        echo "Frontend_CustomerService_should_send_a_POST_request_to_submitApplication_method FAILED";
    fi

    # checking for create-job component
    if [ -d "/home/coder/project/workspace/angularapp/src/app/create-job" ]
    then
        cp /home/coder/project/workspace/karma/create-job.component.spec.ts /home/coder/project/workspace/angularapp/src/app/create-job/create-job.component.spec.ts;
    else
        echo "Frontend_should_have_createJobPosting_function_in_CreateJobComponent FAILED";
    fi

    # checking for auth.service component
    if [ -d "/home/coder/project/workspace/angularapp/src/app/services" ]
    then
        cp /home/coder/project/workspace/karma/auth.service.spec.ts /home/coder/project/workspace/angularapp/src/app/services/auth.service.spec.ts;
    else
        echo "Frontend_should_have_logout_function_in_AuthService FAILED";
        echo "Frontend_should_send_a_POST_request_to_register_a_customer FAILED";
        echo "Frontend_should_send_a_POST_request_to_login FAILED";
    fi

    # checking for auth.guard component
    if [ -d "/home/coder/project/workspace/angularapp/src/app/authguard" ]
    then
        cp /home/coder/project/workspace/karma/auth.guard.spec.ts /home/coder/project/workspace/angularapp/src/app/authguard/auth.guard.spec.ts;
    else
        echo "Frontend_should_create_AuthGuard FAILED";
    fi

    # checking for admin.services component
    if [ -d "/home/coder/project/workspace/angularapp/src/app/services" ]
    then
        cp /home/coder/project/workspace/karma/admin.service.spec.ts /home/coder/project/workspace/angularapp/src/app/services/admin.service.spec.ts;
    else
        echo "Frontend_AdminService_should_retrieve_All_JobPostings_from_the_backend FAILED";
        echo "Frontend_should_have_createJobPosting_function_in_AdminService FAILED";
        echo "Frontend_should_have_updateJobPosting_function_in_AdminService FAILED";
        echo "Frontend_should_have_updateApplication_function_in_AdminService FAILED";
        echo "Frontend_AdminService_should_retrieve_All_Applications_from_the_backend FAILED";
    fi 

    

    if [ -d "/home/coder/project/workspace/angularapp/node_modules" ]; 
    then
        cd /home/coder/project/workspace/angularapp/
        npm test;
    else
        cd /home/coder/project/workspace/angularapp/
        yes | npm install
        npm test
    fi 
	
	

else   
    echo "Frontend_should_create_User_instance FAILED";
    echo "Frontend_should_show_username_required_error_message_on_register_page_RegistrationComponent FAILED";
    echo "Frontend_should_show_password_required_error_message_on_register_page_RegistrationComponent FAILED";
    echo "Frontend_should_show_password_complexity_error_message_on_register_page_RegistrationComponent FAILED";
    echo "Frontend_should_show_confirm_password_required_error_message_on_register_page_RegistrationComponent FAILED";
    echo "Frontend_should_show_passwords_mismatch_error_message_on_register_page_RegistrationComponent FAILED";
    echo "Frontend_LoginComponent FAILED";
    echo "Frontend_call_login_method_on_admin_login_LoginComponent FAILED";
    echo "Frontend_should_call_login_method_on_customer_login_LoginComponent FAILED";
    echo "Frontend_should_have_empty_username_and_password_initially_LoginComponent FAILED";
    echo "Frontend_should_call_login_method_on_form_submission_LoginComponent FAILED";
    echo "Frontend_should_show_username_required_error_message_LoginComponent FAILED";
    echo "Frontend_should_show_password_required_error_message_LoginComponent FAILED";
    echo "Frontend_CustomerService_should_send_a_POST_request_to_submitApplication_method FAILED";
    echo "Frontend_should_have_createJobPosting_function_in_CreateJobComponent FAILED";
    echo "Frontend_should_have_logout_function_in_AuthService FAILED";
    echo "Frontend_should_send_a_POST_request_to_register_a_customer FAILED";
    echo "Frontend_should_send_a_POST_request_to_login FAILED";
    echo "Frontend_should_create_AuthGuard FAILED";
    echo "Frontend_AdminService_should_retrieve_All_JobPostings_from_the_backend FAILED";
    echo "Frontend_should_have_createJobPosting_function_in_AdminService FAILED";
    echo "Frontend_should_have_updateJobPosting_function_in_AdminService FAILED";
    echo "Frontend_should_have_updateApplication_function_in_AdminService FAILED";
    echo "Frontend_AdminService_should_retrieve_All_Applications_from_the_backend FAILED";
fi
