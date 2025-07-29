import axios from 'axios';

export const api = axios.create({
    baseURL:'http://localhost:5259/api/v1/Restaurante/'
})