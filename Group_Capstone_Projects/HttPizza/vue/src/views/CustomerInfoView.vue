<template>
    <div class="page-name" style="margin-left:15%">
        <h1>Customer Information</h1>
        <customer-info-form></customer-info-form>
    </div>
    
    </template>
    
    
    <script>
    import customerInfoForm from '../components/CustomerInfoForm.vue' 

    export default {
        components: {
            customerInfoForm
         },
     };

    </script>
    
    
    <style>
    
    </style>