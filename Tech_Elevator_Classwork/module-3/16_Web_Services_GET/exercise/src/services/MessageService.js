import axios from "axios";

const http = axios.create({
    baseURL: "http://localhost:3000"
});

export default {
    get(messagesId) {
        return http.get(`/messages/${messagesId}`);
    }
}