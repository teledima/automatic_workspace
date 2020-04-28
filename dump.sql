--
-- PostgreSQL database dump
--

-- Dumped from database version 11.6
-- Dumped by pg_dump version 11.6

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: lab6; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE lab6 WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'Russian_Russia.1251' LC_CTYPE = 'Russian_Russia.1251';


ALTER DATABASE lab6 OWNER TO postgres;

\connect lab6

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- Name: answers; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.answers (
    question_id integer NOT NULL,
    user_id_ans integer NOT NULL
);


ALTER TABLE public.answers OWNER TO postgres;

--
-- Name: operator_table; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.operator_table (
    id_user integer NOT NULL,
    login character varying(50) NOT NULL,
    password text NOT NULL,
    is_admin boolean DEFAULT false NOT NULL
);


ALTER TABLE public.operator_table OWNER TO postgres;

--
-- Name: questions; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.questions (
    id_question integer NOT NULL,
    link_id integer,
    count_view integer,
    subject_id integer,
    user_id integer
);


ALTER TABLE public.questions OWNER TO postgres;

--
-- Name: questions_id_question_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.questions_id_question_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.questions_id_question_seq OWNER TO postgres;

--
-- Name: questions_id_question_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.questions_id_question_seq OWNED BY public.questions.id_question;


--
-- Name: statuses; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.statuses (
    id_status integer NOT NULL,
    name text NOT NULL
);


ALTER TABLE public.statuses OWNER TO postgres;

--
-- Name: statuses_id_status_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.statuses_id_status_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.statuses_id_status_seq OWNER TO postgres;

--
-- Name: statuses_id_status_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.statuses_id_status_seq OWNED BY public.statuses.id_status;


--
-- Name: subject; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.subject (
    id integer NOT NULL,
    name text NOT NULL
);


ALTER TABLE public.subject OWNER TO postgres;

--
-- Name: subject_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.subject_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.subject_id_seq OWNER TO postgres;

--
-- Name: subject_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.subject_id_seq OWNED BY public.subject.id;


--
-- Name: users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.users (
    id_user integer NOT NULL,
    login text NOT NULL,
    age integer,
    status_id integer
);


ALTER TABLE public.users OWNER TO postgres;

--
-- Name: users_id_user_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.users_id_user_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.users_id_user_seq OWNER TO postgres;

--
-- Name: users_id_user_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.users_id_user_seq OWNED BY public.users.id_user;


--
-- Name: users_table_id_user_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.users_table_id_user_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.users_table_id_user_seq OWNER TO postgres;

--
-- Name: users_table_id_user_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.users_table_id_user_seq OWNED BY public.operator_table.id_user;


--
-- Name: operator_table id_user; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.operator_table ALTER COLUMN id_user SET DEFAULT nextval('public.users_table_id_user_seq'::regclass);


--
-- Name: questions id_question; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.questions ALTER COLUMN id_question SET DEFAULT nextval('public.questions_id_question_seq'::regclass);


--
-- Name: statuses id_status; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.statuses ALTER COLUMN id_status SET DEFAULT nextval('public.statuses_id_status_seq'::regclass);


--
-- Name: subject id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.subject ALTER COLUMN id SET DEFAULT nextval('public.subject_id_seq'::regclass);


--
-- Name: users id_user; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users ALTER COLUMN id_user SET DEFAULT nextval('public.users_id_user_seq'::regclass);


--
-- Data for Name: answers; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.answers VALUES (4, 29);
INSERT INTO public.answers VALUES (9, 28);
INSERT INTO public.answers VALUES (9, 34);
INSERT INTO public.answers VALUES (10, 28);
INSERT INTO public.answers VALUES (10, 34);
INSERT INTO public.answers VALUES (10, 32);
INSERT INTO public.answers VALUES (9, 35);
INSERT INTO public.answers VALUES (9, 36);
INSERT INTO public.answers VALUES (16, 37);
INSERT INTO public.answers VALUES (7, 39);
INSERT INTO public.answers VALUES (16, 40);
INSERT INTO public.answers VALUES (18, 30);
INSERT INTO public.answers VALUES (18, 29);


--
-- Data for Name: operator_table; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.operator_table VALUES (3, 'fbbb', 'c3aa9967fd02276efddec604a45e34c5', false);
INSERT INTO public.operator_table VALUES (2, 'inf777', '2494660bcaa5da0455bbe4b353b17b57', true);
INSERT INTO public.operator_table VALUES (5, 'strange', 'e1312e295d74270bbfc87635c84191cc', false);
INSERT INTO public.operator_table VALUES (9, 'lalala', '6448b28a890c246b3cd0aff20cbc2843', false);
INSERT INTO public.operator_table VALUES (4, 'deropt', '4cc2dc46c0e6277f8311c9e0b81266dd', false);
INSERT INTO public.operator_table VALUES (1, 'teledima00', '4cc2dc46c0e6277f8311c9e0b81266dd', true);
INSERT INTO public.operator_table VALUES (8, 'test2', 'f6df65c9f82ba91da15f8b22ed969e73', false);
INSERT INTO public.operator_table VALUES (10, 'sia', '1c1beab6abcfea4a178b106ed35af43d', false);
INSERT INTO public.operator_table VALUES (6, 'senior', '1374f6c79a314030a1e23080ed798f43', true);
INSERT INTO public.operator_table VALUES (7, 'test', '309c735a6304ea3df736ff45bc05bc3c', true);


--
-- Data for Name: questions; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.questions VALUES (9, 342, 42, 5, 29);
INSERT INTO public.questions VALUES (10, 5466, 545, 2, 30);
INSERT INTO public.questions VALUES (7, 32, 11, 3, 28);
INSERT INTO public.questions VALUES (4, 5454, 60, 3, NULL);
INSERT INTO public.questions VALUES (16, 234, 21, 2, 34);
INSERT INTO public.questions VALUES (17, 54462, 222, 5, 28);
INSERT INTO public.questions VALUES (18, 5678, 14, 8, 28);


--
-- Data for Name: statuses; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.statuses VALUES (1, 'новичок');
INSERT INTO public.statuses VALUES (3, 'хорошист');
INSERT INTO public.statuses VALUES (8, 'светило науки');
INSERT INTO public.statuses VALUES (9, 'профессор');
INSERT INTO public.statuses VALUES (7, 'почётный грамотей');
INSERT INTO public.statuses VALUES (6, 'учёный');
INSERT INTO public.statuses VALUES (5, 'отличник');
INSERT INTO public.statuses VALUES (10, 'главный мозг');
INSERT INTO public.statuses VALUES (4, 'умный');


--
-- Data for Name: subject; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.subject VALUES (2, 'English language');
INSERT INTO public.subject VALUES (5, 'Chemistry');
INSERT INTO public.subject VALUES (8, 'Mathematics');
INSERT INTO public.subject VALUES (9, 'Geography');
INSERT INTO public.subject VALUES (3, 'History');


--
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.users VALUES (33, 'lilyatomach', 36, 1);
INSERT INTO public.users VALUES (32, 'qwerty', 45, NULL);
INSERT INTO public.users VALUES (30, 'uh19', 29, 7);
INSERT INTO public.users VALUES (35, 'ttttebg', 32, 9);
INSERT INTO public.users VALUES (36, 'hahaha', 16, NULL);
INSERT INTO public.users VALUES (37, 'bebebe', 19, NULL);
INSERT INTO public.users VALUES (39, 'ohoho', 16, 8);
INSERT INTO public.users VALUES (40, 'nononn', 16, 9);
INSERT INTO public.users VALUES (34, 'alex', 19, 10);
INSERT INTO public.users VALUES (29, 'inf777', 16, 10);
INSERT INTO public.users VALUES (28, 'teledima00', 16, 5);


--
-- Name: questions_id_question_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.questions_id_question_seq', 18, true);


--
-- Name: statuses_id_status_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.statuses_id_status_seq', 34, true);


--
-- Name: subject_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.subject_id_seq', 9, true);


--
-- Name: users_id_user_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.users_id_user_seq', 40, true);


--
-- Name: users_table_id_user_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.users_table_id_user_seq', 10, true);


--
-- Name: answers answers_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.answers
    ADD CONSTRAINT answers_pk PRIMARY KEY (question_id, user_id_ans);


--
-- Name: operator_table operator_table_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.operator_table
    ADD CONSTRAINT operator_table_pk PRIMARY KEY (id_user);


--
-- Name: questions questions_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.questions
    ADD CONSTRAINT questions_pk PRIMARY KEY (id_question);


--
-- Name: statuses statuses_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.statuses
    ADD CONSTRAINT statuses_pk PRIMARY KEY (id_status);


--
-- Name: subject subject_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.subject
    ADD CONSTRAINT subject_pk PRIMARY KEY (id);


--
-- Name: users users_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pk PRIMARY KEY (id_user);


--
-- Name: operator_table_login_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX operator_table_login_uindex ON public.operator_table USING btree (login);


--
-- Name: statuses_name_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX statuses_name_uindex ON public.statuses USING btree (name);


--
-- Name: subject_subject_name_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX subject_subject_name_uindex ON public.subject USING btree (name);


--
-- Name: users_login_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX users_login_uindex ON public.users USING btree (login);


--
-- Name: answers answers_questions_id_question_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.answers
    ADD CONSTRAINT answers_questions_id_question_fk FOREIGN KEY (question_id) REFERENCES public.questions(id_question) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: answers answers_users_id_user_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.answers
    ADD CONSTRAINT answers_users_id_user_fk FOREIGN KEY (user_id_ans) REFERENCES public.users(id_user) ON UPDATE SET NULL ON DELETE SET NULL;


--
-- Name: questions questions_subject_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.questions
    ADD CONSTRAINT questions_subject_id_fk FOREIGN KEY (subject_id) REFERENCES public.subject(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: questions questions_users_id_user_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.questions
    ADD CONSTRAINT questions_users_id_user_fk FOREIGN KEY (user_id) REFERENCES public.users(id_user) ON UPDATE SET NULL ON DELETE SET NULL;


--
-- Name: users users_statuses_id_status_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_statuses_id_status_fk FOREIGN KEY (status_id) REFERENCES public.statuses(id_status) ON UPDATE SET NULL ON DELETE SET NULL;


--
-- Name: DATABASE lab6; Type: ACL; Schema: -; Owner: postgres
--

GRANT ALL ON DATABASE lab6 TO admin_db;


--
-- Name: TABLE statuses; Type: ACL; Schema: public; Owner: postgres
--

GRANT ALL ON TABLE public.statuses TO operator_workspace;
GRANT SELECT ON TABLE public.statuses TO quest;


--
-- Name: TABLE users; Type: ACL; Schema: public; Owner: postgres
--

GRANT ALL ON TABLE public.users TO operator_workspace;
GRANT SELECT ON TABLE public.users TO quest;


--
-- PostgreSQL database dump complete
--

