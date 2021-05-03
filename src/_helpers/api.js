import axios from 'axios';

const axiosApi = axios.create({
    // .. where we make our configurations
        baseURL: 'https://localhost:44351/'
    });


    export const getRequest = (api) => {
        const url = `${api}`
        console.log(url);
        //return axios.get(url, { withCredentials: true })
        return axiosApi.get(url)
      }